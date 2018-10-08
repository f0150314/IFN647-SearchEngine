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
            this.AbstractContent = new System.Windows.Forms.Label();
            this.BibliographyContent = new System.Windows.Forms.Label();
            this.AuthorContent = new System.Windows.Forms.Label();
            this.TitleContent = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.BibliographyLabel = new System.Windows.Forms.Label();
            this.AbstractLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(445, 255);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(72, 29);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AbstractContent
            // 
            this.AbstractContent.AutoSize = true;
            this.AbstractContent.Location = new System.Drawing.Point(22, 206);
            this.AbstractContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AbstractContent.Name = "AbstractContent";
            this.AbstractContent.Size = new System.Drawing.Size(83, 13);
            this.AbstractContent.TabIndex = 11;
            this.AbstractContent.Text = "AbstractContent";
            // 
            // BibliographyContent
            // 
            this.BibliographyContent.AutoSize = true;
            this.BibliographyContent.Location = new System.Drawing.Point(22, 141);
            this.BibliographyContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BibliographyContent.Name = "BibliographyContent";
            this.BibliographyContent.Size = new System.Drawing.Size(101, 13);
            this.BibliographyContent.TabIndex = 10;
            this.BibliographyContent.Text = "BibliographyContent";
            // 
            // AuthorContent
            // 
            this.AuthorContent.AutoSize = true;
            this.AuthorContent.Location = new System.Drawing.Point(22, 81);
            this.AuthorContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthorContent.Name = "AuthorContent";
            this.AuthorContent.Size = new System.Drawing.Size(75, 13);
            this.AuthorContent.TabIndex = 9;
            this.AuthorContent.Text = "AuthorContent";
            // 
            // TitleContent
            // 
            this.TitleContent.AutoSize = true;
            this.TitleContent.Location = new System.Drawing.Point(22, 25);
            this.TitleContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleContent.Name = "TitleContent";
            this.TitleContent.Size = new System.Drawing.Size(64, 13);
            this.TitleContent.TabIndex = 8;
            this.TitleContent.Text = "TitleContent";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(22, 21);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(50, 17);
            this.TitleLabel.TabIndex = 12;
            this.TitleLabel.Text = "Title :";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLabel.Location = new System.Drawing.Point(22, 77);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(66, 17);
            this.AuthorLabel.TabIndex = 13;
            this.AuthorLabel.Text = "Author :";
            // 
            // BibliographyLabel
            // 
            this.BibliographyLabel.AutoSize = true;
            this.BibliographyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BibliographyLabel.Location = new System.Drawing.Point(22, 135);
            this.BibliographyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BibliographyLabel.Name = "BibliographyLabel";
            this.BibliographyLabel.Size = new System.Drawing.Size(113, 17);
            this.BibliographyLabel.TabIndex = 14;
            this.BibliographyLabel.Text = "Bibliography : ";
            // 
            // AbstractLabel
            // 
            this.AbstractLabel.AutoSize = true;
            this.AbstractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbstractLabel.Location = new System.Drawing.Point(22, 186);
            this.AbstractLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AbstractLabel.Name = "AbstractLabel";
            this.AbstractLabel.Size = new System.Drawing.Size(83, 17);
            this.AbstractLabel.TabIndex = 15;
            this.AbstractLabel.Text = "Abstract : ";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(546, 306);
            this.Controls.Add(this.AbstractLabel);
            this.Controls.Add(this.BibliographyLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AbstractContent);
            this.Controls.Add(this.TitleContent);
            this.Controls.Add(this.BibliographyContent);
            this.Controls.Add(this.AuthorContent);
            this.Controls.Add(this.CloseButton);
            this.Name = "DisplayForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60);
            this.Text = "DisplayAbstract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label AbstractContent;
        private System.Windows.Forms.Label BibliographyContent;
        private System.Windows.Forms.Label AuthorContent;
        private System.Windows.Forms.Label TitleContent;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label BibliographyLabel;
        private System.Windows.Forms.Label AbstractLabel;
    }
}