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

namespace SearchEngine
{
    public partial class SearchedResults : Form
    {
        SaveDocumentWindow saveWindow;

        int selectedItem;
        public static Document[] ranked_docs;
        public static TopDocs results;
        int displayBatch;

        public SearchedResults(string rawQuery, string elapsed, TopDocs topResults, Document[] docs)
        {
            
            InitializeComponent();
            results = topResults;
            ranked_docs = docs;
            previousButton.Hide();
            label1.Text = "Raw input query: " + rawQuery;
            label2.Text = "Searching time: " + elapsed;
            label3.Text = "Total hits: " + results.TotalHits;
            DisplayResult(results, ranked_docs, displayBatch = 0);

            saveWindow = new SaveDocumentWindow(results);
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
                                          docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { '\r', '\n' }).FirstOrDefault()});
                    dataGridView1.DataSource = dt;
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
                                          docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { '\r', '\n' }).FirstOrDefault()});
                    dataGridView1.DataSource = dt;
                    //ScoreDoc scoreDoc = results.ScoreDocs[i];
                    //Lucene.Net.Documents.Document doc =
                    //item_title = new ListViewItem(results);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedItem = e.RowIndex;
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveWindow.Show();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            displayBatch -= 1;
            DisplayResult(results, ranked_docs, displayBatch);
            Next.Show();
            if (displayBatch == 0)
            {
                previousButton.Hide();
            }
        }

        private void displayItenButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[selectedItem];
            string luceneInextOfSelectedItem = row.Cells[0].Value.ToString();
            int ind = System.Convert.ToInt32(luceneInextOfSelectedItem);

            //Create a new form and display the full abstract (with a cancel/close button)
            DisplayAbstract displayWindows = new DisplayAbstract(ind, ranked_docs);
            displayWindows.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Next_Click_1(object sender, EventArgs e)
        {
            displayBatch++;
            DisplayResult(results, ranked_docs, displayBatch);
            previousButton.Show();
            if (displayBatch == results.TotalHits / 10)
            {
                Next.Hide();
            }
        }
    }
}
