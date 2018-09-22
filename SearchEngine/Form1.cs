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

        public Form1()
        {
            InitializeComponent();
            indexing = new IndexingClass();
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
            }
        }
    }
}
