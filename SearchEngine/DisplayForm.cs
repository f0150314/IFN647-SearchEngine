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
            TitleContent.Text = docs[ind].Get(IndexingClass.FieldTITLE).ToString().Substring(2);

            // The abstract needs to be full abstract
            AuthorContent.Text = docs[ind].Get(IndexingClass.FieldAUTHOR).ToString().Substring(2);

            BibliographyContent.Text = docs[ind].Get(IndexingClass.FieldBIBLIO_INFO).ToString().Substring(2);

            AbstractContent.Text = docs[ind].Get(IndexingClass.FieldABSTRACT).ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
