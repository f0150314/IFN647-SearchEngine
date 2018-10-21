namespace SearchEngine
{
    partial class WikiSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.queryLabel = new System.Windows.Forms.Label();
            this.wikiSearchResultBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryLabel.Location = new System.Drawing.Point(12, 20);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(70, 22);
            this.queryLabel.TabIndex = 0;
            this.queryLabel.Text = "Query:";
            // 
            // wikiSearchResultBox
            // 
            this.wikiSearchResultBox.Location = new System.Drawing.Point(12, 55);
            this.wikiSearchResultBox.Name = "wikiSearchResultBox";
            this.wikiSearchResultBox.Size = new System.Drawing.Size(318, 373);
            this.wikiSearchResultBox.TabIndex = 1;
            this.wikiSearchResultBox.Text = "";
            // 
            // WikiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 440);
            this.Controls.Add(this.wikiSearchResultBox);
            this.Controls.Add(this.queryLabel);
            this.Name = "WikiSearch";
            this.Text = "WikiSearch";
            this.Load += new System.EventHandler(this.WikiSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.RichTextBox wikiSearchResultBox;
    }
}