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

        public SearchedResults(string elapsed, string rawQuery, TopDocs results, Document[] docs)
        {
            InitializeComponent();
            label1.Text = "Raw input query: " + rawQuery;
            label2.Text = "Searching time: " + elapsed;
            label3.Text = "Total hits: " + results.TotalHits;
            Document[] ranked_docs = docs;
            DisplayResult(results, docs);
            saveWindow = new SaveDocumentWindow(results);
        }

        public void DisplayResult(TopDocs results, Document[] docs)
        {
            for (int i = 0; i < results.TotalHits; i++)
            {
                ListViewItem item_abstract;

                // Store the first sentence of the document
                item_abstract = new ListViewItem(docs[i].Get(IndexingClass.FieldABSTRACT).ToString().Split(new[] { '\r', '\n' }).FirstOrDefault());
                
                listView1.Items.Add(item_abstract);
                //ScoreDoc scoreDoc = results.ScoreDocs[i];
                //Lucene.Net.Documents.Document doc =
                //item_title = new ListViewItem(results);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveWindow.Show();
        }
    }
}
