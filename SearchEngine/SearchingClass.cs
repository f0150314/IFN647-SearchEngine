using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;

namespace SearchEngine
{
    class SearchingClass
    {
        // Initialize class variables
        IndexSearcher searcher;
        MultiFieldQueryParser multi_field_query_parser;
        public static string finalQuery;
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        //QueryParser parser_docid;
        //QueryParser parser_title;
        //QueryParser parser_author;
        //QueryParser parser_bib;
        //QueryParser parser_abstract;

        public SearchingClass()
        {

        }

        // The method that searches the given searching query against the index and showing the number of total hits

        // *************************************************************************************
        // Chen whether it is necessary to include the function of searching against title, author etc...
        // *************************************************************************************    
        // return: TopDocs object
        public TopDocs SearchIndex(Directory luceneIndexDirectory, Analyzer analyzer, string queryText, bool phraseState, int top_n = 500)
        {
            // Initialize Searcher and Writer and set similarity
            searcher = new IndexSearcher(luceneIndexDirectory);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            IndexWriter writer = new IndexWriter(luceneIndexDirectory, analyzer, false, mfl);
            writer.SetSimilarity(new NewSimilarity());
            searcher.Similarity = writer.Similarity;

            // Clean up Indexer
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();

            // Initialize multiple field query parser
            multi_field_query_parser = new MultiFieldQueryParser(VERSION, new string [] { IndexingClass.FieldTITLE, IndexingClass.FieldAUTHOR, IndexingClass.FieldBIBLIO_INFO, IndexingClass.FieldABSTRACT}, analyzer); 

            //// Initialize QueryParser
            //parser_docid = new QueryParser(VERSION, IndexingClass.FieldDOC_ID, searchAnalyzer);
            //parser_title = new QueryParser(VERSION, IndexingClass.FieldTITLE, searchAnalyzer);
            //parser_author = new QueryParser(VERSION, IndexingClass.FieldAUTHOR, searchAnalyzer);
            //parser_bib = new QueryParser(VERSION, IndexingClass.FieldBIBLIO_INFO, searchAnalyzer);
            //parser_abstract = new QueryParser(VERSION, IndexingClass.FieldABSTRACT, searchAnalyzer);

            Query query = multi_field_query_parser.Parse(queryText.ToLower());
            TopDocs results = searcher.Search(query, top_n);


            /// <summary>
            /// This section provides explanation for the similarity output, 
            /// delete this after determining the final similarity measures.
            /// <summary>
            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                Document doc = searcher.Doc(scoreDoc.Doc);
                string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                Console.WriteLine(searcher.Explain(query, scoreDoc.Doc));
            }
            ///
            ///


            finalQuery = CreateFinalQueryForDisplay(query, phraseState);
            return results;
        }

        // Create final query for display * still need to improve
        public string CreateFinalQueryForDisplay(Query query, bool phraseState)
        {
            finalQuery = null;

            // if user selects phrase option 
            if (phraseState)
            {
                // if it is multiple term phrase (Information needs: "Information retrieval")
                if (query.ToString().Contains("\""))
                {
                    finalQuery = query.ToString().Split(new[] { '\"' })[1];
                    return finalQuery;
                }

                // if it is single term but using phrase option (Information needs: "Information")
                else
                {
                    finalQuery = query.ToString().Split(new[] { ':', ' ' })[1];
                    return finalQuery;
                }
            }

            // if user does ont select phrase option
            else
            {
                ISet<Term> termSet = new HashSet<Term>();
                query.ExtractTerms(termSet);
                List<string> queryTokenList = new List<string>();
                foreach (var value in termSet)
                {
                    string queryToken = value.ToString().Split(new[] { ':' })[1];
                    if (!queryTokenList.Contains(queryToken))
                        queryTokenList.Add(queryToken);
                }
                for (int i = 0; i < queryTokenList.Count; i++)
                {
                    if (i == 0)
                        finalQuery += queryTokenList[i];
                    else
                        finalQuery += ", " + queryTokenList[i];
                }
                return finalQuery;
            }
        }

        // The method that dispose the searcher
        public void ClearnUpSearcher()
        {
            searcher.Dispose();
        }

        // The method that display the result ordered by its ranking
        public Document[] Get_doc(TopDocs results)
        {
            int ranking = 0;
            Document[] ranked_doc = new Document[results.TotalHits];

            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                ranked_doc[ranking] = searcher.Doc(scoreDoc.Doc);
                ranking++;

                // Retrieve the doc and display the text(abstract)
                //Document doc = searcher.Doc(scoreDoc.Doc);
                //string myFieldValue = doc.Get(TEXT_FN).ToString();
            }
            return ranked_doc;
        }
    }
}
