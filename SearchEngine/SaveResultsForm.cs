using System;
using System.IO;
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
    public partial class SaveResultsForm : Form
    {
        TopDocs topDocResults;

        public SaveResultsForm(TopDocs results)
        {
            InitializeComponent();
            topDocResults = results;
        }

        private void SaveDocumentButton_Click(object sender, EventArgs e)
        {
            // Restrict the storing file type
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save Text File";

            // Disable overwrite alert
            saveFileDialog.OverwritePrompt = false;

            // Check if there is any topic input
            if (!(topicEnter.Text == ""))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int rank = 0;
                    string documentID = null;

                    // Get speficied file path and topic ID
                    string path = saveFileDialog.FileName;
                    string topicID = topicEnter.Text;
                    
                    // Check whether the specified file already exists or not
                    if (File.Exists(path))
                    {
                        // Append new results to existing file if it is true
                        using (StreamWriter stwriter = File.AppendText(path))
                        {
                            foreach (ScoreDoc scorDoc in topDocResults.ScoreDocs)
                            {
                                rank++;

                                // Use searcher to acquire doucment ID
                                using (IndexSearcher searcher = new IndexSearcher(IndexingClass.luceneIndexDirectory))
                                {
                                    documentID = searcher.Doc(scorDoc.Doc).Get(IndexingClass.FieldDOC_ID).ToString();
                                }

                                // Write to the file
                                stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", topicID, "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_HelloWorldteam");
                            }
                        }
                    }                  
                    else
                    {
                        // Create new file if it is false
                        using (StreamWriter stwriter = new StreamWriter(File.Create(path)))
                        {
                            foreach (ScoreDoc scorDoc in topDocResults.ScoreDocs)
                            {
                                rank++;
                                using (IndexSearcher searcher = new IndexSearcher(IndexingClass.luceneIndexDirectory))
                                {
                                    documentID = searcher.Doc(scorDoc.Doc).Get(IndexingClass.FieldDOC_ID).ToString();
                                }
                                stwriter.WriteLine("{0,-4} {1,-4} {2,-7} {3,-5} {4,-11} {5}", topicID, "Q0", documentID, rank, scorDoc.Score, "n9843329_n9861718_HelloWorldteam");
                            }
                        }
                    }
                }
                this.Hide();
            }

            // Notify user if he/she did not specify topic ID
            else
                MessageBox.Show("Please specify topic ID");
        }
    }
}
