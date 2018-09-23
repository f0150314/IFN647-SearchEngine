using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Analysis;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using System.Diagnostics;

namespace SearchEngine
{
    public partial class Searching_Form : Form
    {
        SearchedResults searchedResults;
        SearchingClass searching;
        TopDocs results;
        Stopwatch stopwatch;
        Document[] ranked_docs;

        public Searching_Form()
        {
            InitializeComponent();
            searching = new SearchingClass();
            stopwatch = new Stopwatch();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(queryEnter.Text);
            if (!(queryEnter.Text == ""))
            {
                // Cerate searcher and queryParser
                stopwatch.Restart();
                searching.CreateSearcher(IndexingClass.luceneIndexDirectory);
                searching.CreateParser(IndexingClass.analyzer);

                // Search the query against the index, the default return size is set to be 30
                // retrieve the searching result TopDocs object
                results = searching.SearchIndex(queryEnter.Text);
                stopwatch.Stop();
                string elapsed = stopwatch.Elapsed.ToString();
                ranked_docs = searching.Get_doc(results);
                searching.ClearnUpSearcher();
                searchedResults = new SearchedResults(queryEnter.Text, elapsed, results, ranked_docs);
                // Create new form
                searchedResults.Show();

                this.Hide();
            }

            // Notify user if he/she did not specify topic ID
            else
            {
                MessageBox.Show("You need to specify your query");
            }
        }
    }
}
