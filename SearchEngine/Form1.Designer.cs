namespace SearchEngine
{
    partial class Form1
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
            this.folderBuildIndexDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BuildIndexButton = new System.Windows.Forms.Button();
            this.DirectoryPathLabel = new System.Windows.Forms.Label();
            this.folderCollectionDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CollectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildIndexButton
            // 
            this.BuildIndexButton.Location = new System.Drawing.Point(12, 12);
            this.BuildIndexButton.Name = "BuildIndexButton";
            this.BuildIndexButton.Size = new System.Drawing.Size(203, 23);
            this.BuildIndexButton.TabIndex = 6;
            this.BuildIndexButton.Text = "Select the Index Directory";
            this.BuildIndexButton.UseVisualStyleBackColor = true;
            this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
            // 
            // DirectoryPathLabel
            // 
            this.DirectoryPathLabel.Location = new System.Drawing.Point(236, 12);
            this.DirectoryPathLabel.Name = "DirectoryPathLabel";
            this.DirectoryPathLabel.Size = new System.Drawing.Size(223, 23);
            this.DirectoryPathLabel.TabIndex = 7;
            this.DirectoryPathLabel.Text = "IndexDirectoryPath";
            this.DirectoryPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollectionButton
            // 
            this.CollectionButton.Location = new System.Drawing.Point(12, 41);
            this.CollectionButton.Name = "CollectionButton";
            this.CollectionButton.Size = new System.Drawing.Size(203, 23);
            this.CollectionButton.TabIndex = 8;
            this.CollectionButton.Text = "Source collection path";
            this.CollectionButton.UseVisualStyleBackColor = true;
            this.CollectionButton.Click += new System.EventHandler(this.CollectionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 477);
            this.Controls.Add(this.CollectionButton);
            this.Controls.Add(this.DirectoryPathLabel);
            this.Controls.Add(this.BuildIndexButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBuildIndexDialog;
        private System.Windows.Forms.Button BuildIndexButton;
        private System.Windows.Forms.Label DirectoryPathLabel;
        private System.Windows.Forms.FolderBrowserDialog folderCollectionDialog;
        private System.Windows.Forms.Button CollectionButton;
    }
}

