using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SearchEngine
{
    public partial class Form1 : Form
    {
        IndexingClass indexing;
        Searching_Form searchForm;
        Stopwatch stopwatch;

        bool checkState = false;

        public Form1()
        {
            InitializeComponent();
            indexing = null;
            searchForm = null;
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
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                checkState = true;
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

            searchForm = new Searching_Form();
            searchForm.Show();
            this.Hide();
        }
    }
}
