namespace SearchEngine
{
    partial class DisplayForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.AbstractLabel = new System.Windows.Forms.Label();
            this.BibliographyLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(523, 579);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(72, 29);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AbstractLabel
            // 
            this.AbstractLabel.AutoSize = true;
            this.AbstractLabel.Location = new System.Drawing.Point(28, 195);
            this.AbstractLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AbstractLabel.Name = "AbstractLabel";
            this.AbstractLabel.Size = new System.Drawing.Size(72, 13);
            this.AbstractLabel.TabIndex = 11;
            this.AbstractLabel.Text = "AbstractLabel";
            // 
            // BibliographyLabel
            // 
            this.BibliographyLabel.AutoSize = true;
            this.BibliographyLabel.Location = new System.Drawing.Point(28, 139);
            this.BibliographyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BibliographyLabel.Name = "BibliographyLabel";
            this.BibliographyLabel.Size = new System.Drawing.Size(90, 13);
            this.BibliographyLabel.TabIndex = 10;
            this.BibliographyLabel.Text = "BibliographyLabel";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(28, 81);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(64, 13);
            this.AuthorLabel.TabIndex = 9;
            this.AuthorLabel.Text = "AuthorLabel";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(28, 24);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(53, 13);
            this.TitleLabel.TabIndex = 8;
            this.TitleLabel.Text = "TitleLabel";
            // 
            // DisplayAbstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 630);
            this.Controls.Add(this.AbstractLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.BibliographyLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.CloseButton);
            this.Name = "DisplayAbstract";
            this.Text = "DisplayAbstract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label AbstractLabel;
        private System.Windows.Forms.Label BibliographyLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}