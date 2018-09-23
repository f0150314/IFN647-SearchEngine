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
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SourceCollectionPathLabel = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BuildIndexButton
            // 
            this.BuildIndexButton.Location = new System.Drawing.Point(221, 9);
            this.BuildIndexButton.Name = "BuildIndexButton";
            this.BuildIndexButton.Size = new System.Drawing.Size(166, 23);
            this.BuildIndexButton.TabIndex = 6;
            this.BuildIndexButton.Text = "Select Index Directory";
            this.BuildIndexButton.UseVisualStyleBackColor = true;
            this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
            // 
            // DirectoryPathLabel
            // 
            this.DirectoryPathLabel.Location = new System.Drawing.Point(12, 9);
            this.DirectoryPathLabel.Name = "DirectoryPathLabel";
            this.DirectoryPathLabel.Size = new System.Drawing.Size(203, 23);
            this.DirectoryPathLabel.TabIndex = 7;
            this.DirectoryPathLabel.Text = "IndexDirectoryPath";
            this.DirectoryPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollectionButton
            // 
            this.CollectionButton.Location = new System.Drawing.Point(221, 50);
            this.CollectionButton.Name = "CollectionButton";
            this.CollectionButton.Size = new System.Drawing.Size(166, 23);
            this.CollectionButton.TabIndex = 8;
            this.CollectionButton.Text = "Select collection path";
            this.CollectionButton.UseVisualStyleBackColor = true;
            this.CollectionButton.Click += new System.EventHandler(this.CollectionButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(268, 90);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 11;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // SourceCollectionPathLabel
            // 
            this.SourceCollectionPathLabel.Location = new System.Drawing.Point(12, 50);
            this.SourceCollectionPathLabel.Name = "SourceCollectionPathLabel";
            this.SourceCollectionPathLabel.Size = new System.Drawing.Size(203, 23);
            this.SourceCollectionPathLabel.TabIndex = 12;
            this.SourceCollectionPathLabel.Text = "SourceCollectionPath";
            this.SourceCollectionPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox
            // 
            this.checkBox.Location = new System.Drawing.Point(48, 90);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(167, 24);
            this.checkBox.TabIndex = 0;
            this.checkBox.Text = "Preprocessing the information";
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 129);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.SourceCollectionPathLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.CollectionButton);
            this.Controls.Add(this.DirectoryPathLabel);
            this.Controls.Add(this.BuildIndexButton);
            this.Name = "Form1";
            this.Text = "Select your indexing options";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBuildIndexDialog;
        private System.Windows.Forms.Button BuildIndexButton;
        private System.Windows.Forms.Label DirectoryPathLabel;
        private System.Windows.Forms.FolderBrowserDialog folderCollectionDialog;
        private System.Windows.Forms.Button CollectionButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label SourceCollectionPathLabel;
        private System.Windows.Forms.CheckBox checkBox;
    }
}

