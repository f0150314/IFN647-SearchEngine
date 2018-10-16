using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search.Highlight;

namespace SearchEngine
{
    class SearchingClass
    {
        // Initialize class variables
        IndexSearcher searcher;
        MultiFieldQueryParser multi_field_query_parser;     
        public static string finalQueryDisplay;
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        public SearchingClass()
        {

        }

        // Search Index
        public TopDocs SearchIndex(Directory luceneIndexDirectory, Analyzer analyzer, string queryText, bool phraseState, bool stemState, bool wordNetSelection,int top_n = 500)
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

            // User information needs -> Query query
            Query query = multi_field_query_parser.Parse(queryText.ToLower());           
            Console.WriteLine(query);

            // Query query ->  final query for display and Term list for query expansion
            List<string> termList = new List<string>(); ;            
            finalQueryDisplay = CreateFinalQuery(query, termList, phraseState);
         
            // If wordNet option is selected and wordnet database is loaded
            if (wordNetSelection && MainSearchForm.wordNet.IsLoaded && !stemState)
            {
                List<string> finalExpandedQueryList = new List<string>();
                QueryExpansion(finalExpandedQueryList, termList, phraseState);
               
                // if wordnet does not produce any query
                if (finalExpandedQueryList.Count == 0)
                {
                    TopDocs results = searcher.Search(query, top_n);

                    int rank = 0;
                    foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                    {
                        rank++;
                        Document doc = searcher.Doc(scoreDoc.Doc);
                        string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                        Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                        Console.WriteLine(searcher.Explain(query, scoreDoc.Doc));
                    }

                    return results;
                }

                // if the number of expanded queries is not zero
                else
                {
                    // Create expanded query for searching
                    string expandedQueryConcatenation = string.Join(" ", finalExpandedQueryList);
                    Console.WriteLine(expandedQueryConcatenation);
                    Query expandedQuery = multi_field_query_parser.Parse(expandedQueryConcatenation);
                    TopDocs results = searcher.Search(expandedQuery, top_n);

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
                        Console.WriteLine(searcher.Explain(expandedQuery, scoreDoc.Doc));
                    }
                    ///
                    ///

                    return results;
                }
            }
            else
            {
                TopDocs results = searcher.Search(query, top_n);

                //int rank = 0;
                //foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                //{
                //    rank++;
                //    Document doc = searcher.Doc(scoreDoc.Doc);
                //    string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                //    Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                //    Console.WriteLine(searcher.Explain(query, scoreDoc.Doc));
                //}

                return results;
            }
        }

        // Create final query for display
        public string CreateFinalQuery(Query query, List<string> termList, bool phraseState)
        {
            finalQueryDisplay = null;

            // Get terms from query
            var allTerms = QueryTermExtractor.GetTerms(query);
            foreach (var value in allTerms)
            {
                if (!termList.Contains(value.Term))
                    termList.Add(value.Term);
            }

            // if user selects phrase option 
            if (phraseState)
            {               
                finalQueryDisplay = "\"" + string.Join(" ", termList) + "\"";
                return finalQueryDisplay;
            }
            // if user does ont select phrase option
            else
            {
                finalQueryDisplay = string.Join(", ", termList);
                return finalQueryDisplay;
            }
        }

        // Perform Query Expansion
        public void QueryExpansion(List<string> finalExpandedQueryList, List<string> termList, bool phraseState)
        {
            // final query -> wordnet (not phrase)
            if (!phraseState)
            {
                // Get SynSetlist
                List<string> synWordList = new List<string>();
                foreach (var term in termList)
                {                  
                    foreach (var synSet in MainSearchForm.wordNet.GetSynSets(term))
                    {
                        foreach (var synSetWord in synSet.Words)
                        {
                            if (!synWordList.Contains(synSetWord))
                                synWordList.Add(synSetWord);
                        }
                    }
                }
                // Process the SynSetwords and add it to a finalExpandedQueryList
                foreach (var synWord in synWordList)
                {
                    if (synWord.Contains("_"))
                        finalExpandedQueryList.Add("\"" + synWord.Replace('_', ' ') + "\"");
                    else
                    {
                        // Add weighting to expanded queries if they are identical to final queries  
                        if (termList.Contains(synWord))
                            finalExpandedQueryList.Add(synWord + "^5");
                        else
                            finalExpandedQueryList.Add(synWord);
                    }
                }
            }

            // final query -> wordnet (phrase)
            else
            {
                // Get phrase
                string phrase = string.Join(" ", termList);

                // Get SynSetlist
                List<string> synWordList = new List<string>();
                foreach (var synSet in MainSearchForm.wordNet.GetSynSets(phrase))
                {
                    foreach (var synSetWord in synSet.Words)
                    {
                        if (!synWordList.Contains(synSetWord))
                            synWordList.Add(synSetWord);
                    }
                }
                // Process the SynSetwords and add it to a finalExpandedQueryList
                foreach (var synWord in synWordList)
                {
                    if (synWord.Contains("_"))
                    {
                        // Add weighting to expanded queries if they are identical to final phrase  
                        if (synWord.Replace('_', ' ') == phrase)
                            finalExpandedQueryList.Add("\"" + synWord.Replace('_', ' ') + "\"^5");
                        else
                            finalExpandedQueryList.Add("\"" + synWord.Replace('_', ' ') + "\"");
                    }
                    else
                        finalExpandedQueryList.Add(synWord);
                }
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
