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
    public partial class DisplayForm : Form
    {
        public DisplayForm(int ind, Document[] docs)
        {
            InitializeComponent();
            TitleLabel.Text = "Title:\t" + docs[ind].Get(IndexingClass.FieldTITLE).ToString();

            // The abstract needs to be full abstract
            AuthorLabel.Text = "Author:\t" + docs[ind].Get(IndexingClass.FieldAUTHOR).ToString();

            BibliographyLabel.Text = "Bibliography:\t" + docs[ind].Get(IndexingClass.FieldBIBLIO_INFO).ToString();

            AbstractLabel.Text = "Abstract:\n" + docs[ind].Get(IndexingClass.FieldABSTRACT).ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
