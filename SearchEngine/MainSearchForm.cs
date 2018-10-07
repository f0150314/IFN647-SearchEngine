using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using System.Diagnostics;
using System.IO;

namespace SearchEngine
{
    public partial class MainSearchForm : Form
    {
        IndexingClass indexing;
        SearchingClass searching;
        SaveResultsForm saveWindow;
        Stopwatch stopwatch;

        bool indexingState = false;
        bool checkState = false;
        bool phrase = false;
        int selectedItem;
        int displayBatch;
        string inputQuery = null;
        public static Document[] ranked_docs;
        public static TopDocs results;

        public MainSearchForm()
        {           
            InitializeComponent();
            PreviousButton.Hide();
            NextButton.Hide();
            SaveButton.Hide();
            DisplayItenButton.Hide();
        }

        private void BuildIndexButton_Click(object sender, EventArgs e)
        {           
            if (folderBuildIndexDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryPathLabel.Text = folderBuildIndexDialog.SelectedPath;
            }
        }

        private void CollectionButton_Click(object sender, EventArgs e)
        {
            if (folderCollectionDialog.ShowDialog() == DialogResult.OK)
            {
                SourceCollectionPathLabel.Text = folderCollectionDialog.SelectedPath;
            }
        }

        private void PreprocessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PreprocessCheckBox.Checked)
                checkState = true;
            else
                checkState = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            indexing = new IndexingClass();

            stopwatch.Restart();
            indexing.OpenIndex(DirectoryPathLabel.Text, checkState);
            indexing.WalkDirectoryTree(SourceCollectionPathLabel.Text);
            stopwatch.Stop();

            var timeElapsed = stopwatch.Elapsed;
            MessageBox.Show($"Indexing time: {timeElapsed} seconds");
            indexing.CleanUpIndexer();
            indexingState = true;
        }

        //Something wrong with this part...when i click the check box, it never execute the if statement...
        private void PhraseFormCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (PhraseFormCheckbox.Checked)
                phrase = true;
            else
                phrase = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (indexingState == true)
            {
                if (!(QueryEnter.Text == ""))
                {                 
                    if (phrase)
                        inputQuery = "\"" + QueryEnter.Text + "\"";
                    else
                        inputQuery = QueryEnter.Text;
                    searching = new SearchingClass();

                    stopwatch.Restart();
                    // Search the query against the index, the default return size is set to be 30
                    // retrieve the searching result TopDocs object
                    results = searching.SearchIndex(IndexingClass.luceneIndexDirectory, IndexingClass.analyzer, inputQuery);
                    stopwatch.Stop();

                    string elapsed = stopwatch.Elapsed.ToString();
                    ranked_docs = searching.Get_doc(results);
                    searching.ClearnUpSearcher();

                    
                    // Display Searching info 
                    FinalQueryLabel.Text = "Final query: " + SearchingClass.finalQuery;
                    SearchingTimeLabel.Text = "Searching time: " + elapsed;
                    TotalHitsLabel.Text = "Total hits: " + results.TotalHits;
                    DisplayResult(results, ranked_docs, displayBatch = 0);

                    // Only show these button when totalhits is not zero
                    if (results.TotalHits != 0)
                    {
                        DisplayItenButton.Show();
                        SaveButton.Show();
                        NextButton.Show();
                    }
                    else
                    {
                        PreviousButton.Hide();
                        NextButton.Hide();
                        SaveButton.Hide();
                        DisplayItenButton.Hide();
                    }
                }
                // Notify user if he/she did not specify topic ID
                else
                    MessageBox.Show("You need to specify your query");
            }
            else
                MessageBox.Show("You need to do indexing before seaching");        
        }

        public void DisplayResult(TopDocs results, Document[] docs, int displayBatch)
        {
            /*
            if (results.TotalHits == 0)
            {
                DataTable dt = new DataTable();
                dt.Rows.Add(new object[] { "No mathch" });
            }
            */
            if (displayBatch < results.TotalHits / 10)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("No.", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Biblio_info", typeof(string));
                dt.Columns.Add("Abstract", typeof(string));

                for (int i = displayBatch * 10; i < displayBatch * 10 + 10; i++)
                {
                    // Store the first sentence of the document
                    dt.Rows.Add(new object[] {i,
                                          docs[i].Get(IndexingClass.FieldTITLE).ToString(),
                                          docs[i].Get(IndexingClass.FieldAUTHOR).ToString(),
                                          docs[i].Get(IndexingClass.FieldBIBLIO_INFO).ToString(),
                                          docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { " ." }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()});
                    SearchedResultView.DataSource = dt;
                    //ScoreDoc scoreDoc = results.ScoreDocs[i];
                    //Lucene.Net.Documents.Document doc =
                    //item_title = new ListViewItem(results);
                }
            }

            if (displayBatch == results.TotalHits / 10)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("No.", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Biblio_info", typeof(string));
                dt.Columns.Add("Abstract", typeof(string));

                for (int i = displayBatch * 10; i < results.TotalHits; i++)
                {
                    // Store the first sentence of the document
                    dt.Rows.Add(new object[] {i,
                                          docs[i].Get(IndexingClass.FieldTITLE).ToString(),
                                          docs[i].Get(IndexingClass.FieldAUTHOR).ToString(),
                                          docs[i].Get(IndexingClass.FieldBIBLIO_INFO).ToString(),
                                          docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { " ." }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()});
                                          //docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { '\r', '\n' }).FirstOrDefault()});
                    SearchedResultView.DataSource = dt;
                    //ScoreDoc scoreDoc = results.ScoreDocs[i];
                    //Lucene.Net.Documents.Document doc =
                    //item_title = new ListViewItem(results);
                }
            }

            // Show empty info when 0 result is found
            if (results.TotalHits == 0)
                SearchedResultView.DataSource = null;
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            displayBatch -= 1;
            DisplayResult(results, ranked_docs, displayBatch);
            NextButton.Show();

            if (displayBatch <= 0)
                PreviousButton.Hide();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            displayBatch++;
            DisplayResult(results, ranked_docs, displayBatch);
            PreviousButton.Show();

            if (displayBatch >= results.TotalHits / 10)
                NextButton.Hide();
        }

        private void SearchedResultView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedItem = e.RowIndex;
        }

        private void DisplayItenButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = SearchedResultView.Rows[selectedItem];
            string luceneInextOfSelectedItem = row.Cells[0].Value.ToString();
            int ind = System.Convert.ToInt32(luceneInextOfSelectedItem);

            //Create a new form and display the full abstract (with a cancel/close button)
            DisplayForm displayWindows = new DisplayForm(ind, ranked_docs);
            displayWindows.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveWindow = new SaveResultsForm(results);
            saveWindow.Show();
        }

        private void AutoParsing_Click(object sender, EventArgs e)
        {
            saveInfoDialog.Filter = "Text File|*.txt";
            saveInfoDialog.Title = "Save Text File";

            if (indexingState == true)
            {
                if (saveInfoDialog.ShowDialog() == DialogResult.OK)
                {
                    string documentID = null;
                    int index = 0;

                    // Get speficied file path and topic ID
                    string path = saveInfoDialog.FileName;

                    //MessageBox.Show(Resource.cran_information_needs); 
                    List<string> infoID = new List<string>();
                    List<string> infoNeeds = new List<string>();

                    string[] delimeters = { ".I ", ".D" };
                    string[] infoTokens = Resource.cran_information_needs.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < infoTokens.Length; i++)
                    {
                        if (i % 2 == 0)
                            infoID.Add(infoTokens[i]);
                        else
                            infoNeeds.Add(infoTokens[i]);
                    }

                    // Print out the results across each information needs
                    foreach (var infoNeed in infoNeeds)
                    {
                        int rank = 0; 
                        searching = new SearchingClass();
                        TopDocs infoResults = searching.SearchIndex(IndexingClass.luceneIndexDirectory, IndexingClass.analyzer, infoNeed);

                        searching.ClearnUpSearcher();

                        if (File.Exists(path))
                        {
                            using (StreamWriter stwriter = File.AppendText(path))
                            {
                                foreach (ScoreDoc scorDoc in infoResults.ScoreDocs)
                                {
                                    rank++;
                                    // Use searcher to acquire doucment ID
                                    using (IndexSearcher searcher = new IndexSearcher(IndexingClass.luceneIndexDirectory))
                                    {
                                        documentID = searcher.Doc(scorDoc.Doc).Get(IndexingClass.FieldDOC_ID).ToString();
                                        char[] delimeter = { '\n' };
                                        documentID = documentID.Split(delimeter)[0];
                                    }

                                    // Write to the file
                                    stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", infoID[index].Substring(0, 3), "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_HelloWorldteam");
                                }
                            }
                        }
                        else
                        {
                            using (StreamWriter stwriter = new StreamWriter(File.Create(path)))
                            {
                                foreach (ScoreDoc scorDoc in infoResults.ScoreDocs)
                                {
                                    rank++;
                                    using (IndexSearcher searcher = new IndexSearcher(IndexingClass.luceneIndexDirectory))
                                    {
                                        documentID = searcher.Doc(scorDoc.Doc).Get(IndexingClass.FieldDOC_ID).ToString();
                                        char[] delimeter = { '\n' };
                                        documentID = documentID.Split(delimeter)[0];
                                    }
                                    stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", infoID[index].Substring(0, 3), "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_HelloWorldteam");
                                }
                            }
                        }
                        index++;
                    }
                }
            }
            else
                MessageBox.Show("You need to do indexing before seaching");
        }

        private void SearchingBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
