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
using Syn.WordNet;

namespace SearchEngine
{
    public partial class MainSearchForm : Form
    {
        IndexingClass indexing;
        SearchingClass searching;
        Stopwatch stopwatch = new Stopwatch();

        bool indexingState = false;
        bool selectIndexPathState = false;
        bool selectCollectionPathState = false;
        int selectedItem;
        int displayBatch;
        string inputQuery = null;
        public static WordNetEngine wordNet = new WordNetEngine();
        public static Document[] ranked_docs;
        public static TopDocs results;
        public static float titleBoost = 1;
        public static float authorBoost = 1;
        public static float bibliBoost = 1;
        public static float abstractBoost = 1;

        public MainSearchForm()
        {           
            InitializeComponent();
            TitleBoostBox.Enabled = false;
            AuthorBoostBox.Enabled = false;
            BibliBoostBox.Enabled = false;
            AbstractBoostBox.Enabled = false;
            LoadDatabaseButton.Enabled = false;
            TitleBoostBox.Text = "1.0";
            AuthorBoostBox.Text = "1.0";
            BibliBoostBox.Text = "1.0";
            AbstractBoostBox.Text = "1.0";
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
                selectIndexPathState = true;
            }
        }

        private void CollectionButton_Click(object sender, EventArgs e)
        {
            if (folderCollectionDialog.ShowDialog() == DialogResult.OK)
            {
                SourceCollectionPathLabel.Text = folderCollectionDialog.SelectedPath;
                selectCollectionPathState = true;
            }
        }

        // Enable the textbox after checkbox is checked. If checkbox = false, set to default boost value 1
        private void TitleBoostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TitleBoostCheckBox.Checked)
            {
                TitleBoostBox.Enabled = true;
            }
            else
            {
                TitleBoostBox.Enabled = false;
                titleBoost = 1;
            }
        }

        private void AuthorBoostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AuthorBoostCheckBox.Checked)
            {
                AuthorBoostBox.Enabled = true;
            }
            else
            {
                AuthorBoostBox.Enabled = false;
                authorBoost = 1;
            }
        }

        private void BibliBoostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BibliBoostCheckBox.Checked)
            {
                BibliBoostBox.Enabled = true;
            }
            else
            {
                BibliBoostBox.Enabled = false;
                bibliBoost = 1;
            }
        }

        private void AbstractBoostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AbstractBoostCheckBox.Checked)
            {
                AbstractBoostBox.Enabled = true;
            }
            else
            {
                AbstractBoostBox.Enabled = false;
                abstractBoost = 1;
            }
        }

        private void StemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StemCheckBox.Checked)
                MessageBox.Show("Note: Query expansion cannot be applied to stemming");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Check if the both paths are selected before indexing
            if (selectIndexPathState == true && selectCollectionPathState == true)
            {
                if (TitleBoostCheckBox.Checked)
                    titleBoost = float.Parse(TitleBoostBox.Text);
                if (AuthorBoostCheckBox.Checked)
                    authorBoost = float.Parse(AuthorBoostBox.Text);
                if (BibliBoostCheckBox.Checked)
                    bibliBoost = float.Parse(BibliBoostBox.Text);
                if (AbstractBoostCheckBox.Checked)
                    abstractBoost = float.Parse(AbstractBoostBox.Text);

                indexing = new IndexingClass();               

                // Record indexing time
                stopwatch.Restart();
                indexing.OpenIndex(DirectoryPathLabel.Text, StemCheckBox.Checked);
                indexing.WalkDirectoryTree(SourceCollectionPathLabel.Text);
                stopwatch.Stop();

                // Clean up indexer
                indexing.CleanUpIndexer();
                MessageBox.Show($"Indexing time: {stopwatch.Elapsed.ToString()} seconds", "Indexing Time");
                indexingState = true;

                // Notify user which analyzer they are currently using
                if (indexingState && StemCheckBox.Checked)
                    AnalyzseLabel.Text = "Analyzer: Snowball Analyzer (Stemming)";
                else if (indexingState && !StemCheckBox.Checked)
                    AnalyzseLabel.Text = "Analyzer: Standard Analyzer";
            }
            else
                MessageBox.Show("You need to do select both indexing and collection paths before start indexing");
        }

        private void QueryExpansionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (QueryExpansionCheckBox.Checked && !wordNet.IsLoaded)
            {
                MessageBox.Show("Please load wordnet database");
                LoadDatabaseButton.Enabled = true;
            }
            else
                LoadDatabaseButton.Enabled = false;
        }

        // Load wordnet data
        private void LoadDatabaseButton_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
            MessageBox.Show("Loading database");
            wordNet.LoadFromDirectory(directoryPath);
            MessageBox.Show("Load completed");
            LoadDatabaseButton.Text = "Database is loaded.";
            LoadDatabaseButton.Enabled = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Check if the document has already indexed
            if (indexingState == true)
            {
                // Check if the query is empty
                if (!(QueryEnter.Text == ""))
                {
                    // Determine whether the query should be remain orginal form 
                    if (PhraseFormCheckbox.Checked)                   
                        inputQuery = "\"" + QueryEnter.Text + "\"";
                    else
                        inputQuery = QueryEnter.Text;

                    searching = new SearchingClass();

                    // Search the query against the index, the default return size is set to be 30
                    // retrieve the searching result TopDocs object
                    stopwatch.Restart();             
                    results = searching.SearchIndex(IndexingClass.luceneIndexDirectory, IndexingClass.analyzer, inputQuery, PhraseFormCheckbox.Checked, StemCheckBox.Checked,  QueryExpansionCheckBox.Checked);
                    stopwatch.Stop();

                    // Display Searching info                   
                    FinalQueryLabel.Text = "Final query: " + SearchingClass.finalQueryDisplay;
                    SearchingTimeLabel.Text = "Searching time: " + stopwatch.Elapsed.ToString();
                    TotalHitsLabel.Text = "Total hits: " + results.TotalHits;

                    // Acquire the ranked documents and display the results and clean up searcher
                    ranked_docs = searching.Get_doc(results);
                    searching.ClearnUpSearcher();
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

                // Modify column width only if datasource has data
                if (SearchedResultView.DataSource != null)
                {
                    SearchedResultView.Columns[0].Width = 30;
                    SearchedResultView.Columns[1].Width = 150;
                    SearchedResultView.Columns[2].Width = 100;
                    SearchedResultView.Columns[3].Width = 100;
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

                // Modify column width only if datasource has data
                if (SearchedResultView.DataSource != null)
                {
                    SearchedResultView.Columns[0].Width = 30;
                    SearchedResultView.Columns[1].Width = 150;
                    SearchedResultView.Columns[2].Width = 100;
                    SearchedResultView.Columns[3].Width = 100;
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

        private void SearchedResultView_CellClick(object sender, DataGridViewCellEventArgs e)
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

        // pop up save window
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveResultsForm saveWindow = new SaveResultsForm(results);
            saveWindow.Show();
        }

        // Create results for trec_val evaluation
        private void AutoParsing_Click(object sender, EventArgs e)
        {
            saveInfoDialog.Filter = "Text File|*.txt";
            saveInfoDialog.Title = "Save Text File";

            // Check if it has already indexed
            if (indexingState == true)
            {
                if (saveInfoDialog.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    string documentID = null;                

                    // Get speficied file path and topic ID
                    string path = saveInfoDialog.FileName;

                    List<string> infoID = new List<string>();
                    List<string> infoNeeds = new List<string>();

                    // Preprocess the document
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
                        TopDocs infoResults = searching.SearchIndex(IndexingClass.luceneIndexDirectory, IndexingClass.analyzer, infoNeed, PhraseFormCheckbox.Checked, StemCheckBox.Checked, QueryExpansionCheckBox.Checked);
                        searching.ClearnUpSearcher();

                        // Check whether the specified file is already exists or not
                        if (File.Exists(path))
                        {
                            // Append new results to existing file if it is true
                            using (StreamWriter stwriter = File.AppendText(path))
                            {
                                foreach (ScoreDoc scorDoc in infoResults.ScoreDocs)
                                {
                                    rank++;
                                    // Use searcher to acquire doucment ID
                                    using (IndexSearcher searcher = new IndexSearcher(IndexingClass.luceneIndexDirectory))
                                    {
                                        documentID = searcher.Doc(scorDoc.Doc).Get(IndexingClass.FieldDOC_ID).ToString();
                                        documentID = documentID.Split(new[] { '\n' })[0];
                                    }

                                    // Write to the file
                                    stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", infoID[index].Substring(0, 3), "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_n5767032_HelloWorldTeam");
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
                                        documentID = documentID.Split(new[] { '\n' })[0];
                                    }
                                    stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", infoID[index].Substring(0, 3), "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_n5767032_HelloWorldTeam");
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
    }
}
