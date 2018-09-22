using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchEngine
{
    public partial class Form1 : Form
    {
        IndexingClass indexing;
        Searching_Form searchForm; 

        public Form1()
        {
            InitializeComponent();
            indexing = new IndexingClass();
            searchForm = new Searching_Form();
        }

        private void BuildIndexButton_Click(object sender, EventArgs e)
        {
            if (folderBuildIndexDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryPathLabel.Text = folderBuildIndexDialog.SelectedPath;                
                indexing.OpenIndex(DirectoryPathLabel.Text);
            }
        }

        private void CollectionButton_Click(object sender, EventArgs e)
        {
            if (folderCollectionDialog.ShowDialog() == DialogResult.OK)
            {
                string collectionPath = folderCollectionDialog.SelectedPath;
                indexing.WalkDirectoryTree(collectionPath);
                indexing.CleanUpIndexer();               
                searchForm.Show();
                this.Hide();
            }
        }
    }
}
