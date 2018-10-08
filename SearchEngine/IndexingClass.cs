using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Snowball;

namespace SearchEngine
{
    public class IndexingClass
    {
        System.IO.StreamReader reader;
        IndexWriter writer;
        ISet<string> stopwords;

        public static Directory luceneIndexDirectory;
        public static Analyzer analyzer;
        
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        public static string FieldDOC_ID = "DocID";
        public static string FieldTITLE = "Title";
        public static string FieldAUTHOR = "Author";
        public static string FieldBIBLIO_INFO = "BiblioInfo";
        public static string FieldABSTRACT = "Abstract";

        public IndexingClass()
        {
            reader = null;
            luceneIndexDirectory = null;
            writer = null;
            stopwords = Stopwords();
        }

        // Create stopwords list
        public ISet<string> Stopwords()
        {
            List<string> stopwordList = new List<string>();
            char[] delimiters = { '\t', ' ', '\n' };
            stopwordList = Resource.StopwordList.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
            ISet<string> stopwordSet = new HashSet<string>(stopwordList);
            return stopwordSet;
        }

        // Open index and initialize analyzer and indexWriter
        public void OpenIndex(string DirectoryPath, bool processingState)
        {
            luceneIndexDirectory = FSDirectory.Open(DirectoryPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            
            // Decide which analyzer should be used
            if (!processingState)
            {
                analyzer = new StandardAnalyzer(VERSION, stopwords);
                writer = new IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            }
            else
            {
                analyzer = new SnowballAnalyzer(VERSION, "English", stopwords);
                writer = new IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            }
        }

        // Read through all files
        public void WalkDirectoryTree(string collectionPath)
        {
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(collectionPath);
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            if (files != null)
            {
                // Process every file
                foreach (System.IO.FileInfo fi in files)
                {
                    string name = fi.FullName;
                    IndexingDocuments(name);
                }
                reader.Close();

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                // Resursive call for each subdirectory.
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    string name = dirInfo.FullName;
                    WalkDirectoryTree(name);
                }
            }     
        }

        // Preprocess documents and add to index
        public void IndexingDocuments(string name)
        {
            // Preprocessing document (remove abstract error)
            reader = new System.IO.StreamReader(name);
            string text = reader.ReadToEnd();
            string[] delimiters = { ".I ", ".T", ".A", ".B", ".W" };
            string[] docInfo = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            docInfo[4] = docInfo[4].Remove(0, docInfo[1].Length);

            // Creating Index for four different fields
            Field doc_ID = new Field(FieldDOC_ID, docInfo[0], Field.Store.YES, Field.Index.NO, Field.TermVector.NO);
            Field title = new Field(FieldTITLE, docInfo[1], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Field author = new Field(FieldAUTHOR, docInfo[2], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Field bibliography = new Field(FieldBIBLIO_INFO, docInfo[3], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Field abstrat = new Field(FieldABSTRACT, docInfo[4], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);

            // Default boosting value = 1, boosting level changes when user specify the value 
            title.Boost = MainSearchForm.titleBoost;
            author.Boost = MainSearchForm.authorBoost;
            bibliography.Boost = MainSearchForm.bibliBoost;
            abstrat.Boost = MainSearchForm.abstractBoost;

            Document doc = new Document();
            doc.Add(doc_ID);
            doc.Add(title);
            doc.Add(author);
            doc.Add(bibliography);
            doc.Add(abstrat);
            writer.AddDocument(doc);
        }

        // Clean up Indexer
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }
    }
}
