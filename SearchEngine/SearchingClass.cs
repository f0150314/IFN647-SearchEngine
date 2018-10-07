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
        QueryParser parser_docid;
        QueryParser parser_title;
        QueryParser parser_author;
        QueryParser parser_bib;
        QueryParser parser_abstract;

        public static Query query;

        // Initialize constant variables
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        
        public SearchingClass()
        {

        }


        // The method that searches the given searching query against the index and showing the number of total hits

        // *************************************************************************************
        // Chen whether it is necessary to include the function of searching against title, author etc...
        // *************************************************************************************    
        // return: TopDocs object
        public TopDocs SearchIndex(Directory luceneIndexDirectory, Analyzer searchAnalyzer, string queryText, int top_n = 500)
        {
            // Initialize Searcher
            searcher = new IndexSearcher(luceneIndexDirectory);

            // Initialize QueryParser
            parser_docid = new QueryParser(VERSION, IndexingClass.FieldDOC_ID, searchAnalyzer);
            parser_title = new QueryParser(VERSION, IndexingClass.FieldTITLE, searchAnalyzer);
            parser_author = new QueryParser(VERSION, IndexingClass.FieldAUTHOR, searchAnalyzer);
            parser_bib = new QueryParser(VERSION, IndexingClass.FieldBIBLIO_INFO, searchAnalyzer);
            parser_abstract = new QueryParser(VERSION, IndexingClass.FieldABSTRACT, searchAnalyzer);

            queryText = queryText.ToLower();
            query = parser_abstract.Parse(queryText);
            TopDocs results = searcher.Search(query, top_n);

            return results;
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
