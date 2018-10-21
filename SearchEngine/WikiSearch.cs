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
    public partial class WikiSearch : Form
    {
        string Query = null;
        string Result = null;
        public WikiSearch(string query, string result)
        {
            InitializeComponent();
            Query = query;
            Result = result;
        }

        private void WikiSearch_Load(object sender, EventArgs e)
        {
            queryLabel.Text = "Query: " + Query;
            if (Result == string.Empty)
                wikiSearchResultBox.Text = "No result is found";
            else
                wikiSearchResultBox.Text = Result;
        }
    }
}
