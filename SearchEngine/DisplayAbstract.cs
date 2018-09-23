using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Documents;

namespace SearchEngine
{
    public partial class DisplayAbstract : Form
    {
        public DisplayAbstract(int ind, Document[] docs)
        {
            InitializeComponent();
            label1.Text = "Title: \t" + docs[ind].Get(IndexingClass.FieldTITLE).ToString();

            // The abstract needs to be full abstract
            label2.Text = "Author: \t" + docs[ind].Get(IndexingClass.FieldAUTHOR).ToString();

            label3.Text = "Bibliography: \t" + docs[ind].Get(IndexingClass.FieldBIBLIO_INFO).ToString();

            label4.Text = "Abstract: \n" + docs[ind].Get(IndexingClass.FieldABSTRACT).ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
