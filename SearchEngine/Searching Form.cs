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
    public partial class Searching_Form : Form
    {
        SearchedResults searchedResults;
        public Searching_Form()
        {
            InitializeComponent();
            searchedResults = new SearchedResults();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {            
            MessageBox.Show(queryEnter.Text);
            searchedResults.Show();
            this.Hide();
        }
    }
}
