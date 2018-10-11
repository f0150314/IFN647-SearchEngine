﻿using System;
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
using Syn.WordNet;

namespace SearchEngine
{
    class SearchingClass
    {
        // Initialize class variables
        IndexSearcher searcher;
        MultiFieldQueryParser multi_field_query_parser;
        List<string> finalQueryTokenList;
        public static string finalQueryDisplay;
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        public SearchingClass()
        {

        }

        // Search Index
        public TopDocs SearchIndex(Directory luceneIndexDirectory, Analyzer analyzer, string queryText, bool phraseState, bool wordNetSelection,int top_n = 500)
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

            // Query query ->  final query
            finalQueryDisplay = CreateFinalQuery(query, phraseState);

            // If wordNet option is selected and wordnet database is loaded and not phrase
            if (wordNetSelection && MainSearchForm.wordNet.IsLoaded && !phraseState)
            {
                // final query -> wordnet  (ignore phrase because wordnet do not accpet phrase input)
                string[] expandedQueryArray = null;
                foreach (var finalQueryToken in finalQueryTokenList)
                {
                    expandedQueryArray = QueryExpansion(finalQueryToken);
                }

                // if wordnet does not produce any query
                if (expandedQueryArray.Length == 0)
                {
                    TopDocs results = searcher.Search(query, top_n);

                    ///// <summary>
                    ///// This section provides explanation for the similarity output, 
                    ///// delete this after determining the final similarity measures.
                    ///// <summary>
                    //int rank = 0;
                    //foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                    //{
                    //    rank++;
                    //    Document doc = searcher.Doc(scoreDoc.Doc);
                    //    string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                    //    Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                    //    Console.WriteLine(searcher.Explain(query, scoreDoc.Doc));
                    //}
                    /////
                    /////

                    return results;
                }

                // if the number of expanded queries is not zero
                else
                {
                    // Create expanded query for searching
                    string expandedQueryConcatenation = string.Join(" ", expandedQueryArray);
                    //Console.WriteLine(expandedQueryConcatenation);
                    Query expandedQuery = multi_field_query_parser.Parse(expandedQueryConcatenation);
                    TopDocs results = searcher.Search(expandedQuery, top_n);

                    ///// <summary>
                    ///// This section provides explanation for the similarity output, 
                    ///// delete this after determining the final similarity measures.
                    ///// <summary>
                    //int rank = 0;
                    //foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                    //{
                    //    rank++;
                    //    Document doc = searcher.Doc(scoreDoc.Doc);
                    //    string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                    //    Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                    //    Console.WriteLine(searcher.Explain(expandedQuery, scoreDoc.Doc));
                    //}
                    /////
                    /////

                    return results;
                }
            }
            else
            {
                TopDocs results = searcher.Search(query, top_n);

                ///// <summary>
                ///// This section provides explanation for the similarity output, 
                ///// delete this after determining the final similarity measures.
                ///// <summary>
                //int rank = 0;
                //foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                //{
                //    rank++;
                //    Document doc = searcher.Doc(scoreDoc.Doc);
                //    string value = doc.Get(IndexingClass.FieldABSTRACT).ToString();
                //    Console.WriteLine("Rank: " + rank + ", Doc_idx: " + scoreDoc.Doc + ", text: " + value + ", relevance score: " + scoreDoc.Score);
                //    Console.WriteLine(searcher.Explain(query, scoreDoc.Doc));
                //}
                /////
                /////

                return results;
            }
        }

        // Create final query for display
        public string CreateFinalQuery(Query query, bool phraseState)
        {
            finalQueryDisplay = null;

            // if user selects phrase option 
            if (phraseState)
            {
                // if it is multiple term phrase (Information needs: "Information retrieval")
                if (query.ToString().Contains("\""))
                {
                    finalQueryDisplay = query.ToString().Split(new[] { '\"' })[1];
                    return finalQueryDisplay;
                }

                // if it is single term but using phrase option (Information needs: "Information")
                else
                {
                    finalQueryDisplay = query.ToString().Split(new[] { ':', ' ' })[1];
                    return finalQueryDisplay;
                }
            }

            // if user does ont select phrase option
            else
            {
                // Extract terms from query created by query parser
                ISet<Term> termSet = new HashSet<Term>();
                query.ExtractTerms(termSet);
                finalQueryTokenList = new List<string>();

                // Process the query and remove repeated one
                foreach (var value in termSet)
                {
                    string queryToken = value.ToString().Split(new[] { ':' })[1];
                    if (!finalQueryTokenList.Contains(queryToken))
                        finalQueryTokenList.Add(queryToken);
                }

                finalQueryDisplay = string.Join(", ", finalQueryTokenList.ToArray());
                return finalQueryDisplay;
            }
        }

        // Perform Query Expansion
        public string[] QueryExpansion(string finalQueryToken)
        {     
            // Get SynSetlist
            var synSetList = MainSearchForm.wordNet.GetSynSets(finalQueryToken);

            //if (synSetList.Count == 0)
            //    Console.WriteLine($"No synset found for {finalQueryToken}");

            // Remove repeatedness of words 
            List<string> synWordList = new List<string>();
            foreach (var synSet in synSetList)
            {
                foreach (var synSetWord in synSet.Words)
                {                  
                    if (!synWordList.Contains(synSetWord))
                        synWordList.Add(synSetWord);
                } 
            }

            // Process the SynSetwords and add it to a new list
            List<string> newSynWordList = new List<string>();
            foreach (var synWord in synWordList)
            {
                if (synWord.Contains("_"))
                    newSynWordList.Add("\"" + synWord.Replace('_', ' ') + "\"");
                else
                    newSynWordList.Add(synWord);
            }
            return newSynWordList.ToArray();
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
