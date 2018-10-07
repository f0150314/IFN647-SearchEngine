namespace SearchEngine
{
    partial class MainSearchForm
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
            this.FinalQueryLabel = new System.Windows.Forms.Label();
            this.SearchingTimeLabel = new System.Windows.Forms.Label();
            this.TotalHitsLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SearchedResultView = new System.Windows.Forms.DataGridView();
            this.DisplayItenButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.IndexingBox = new System.Windows.Forms.GroupBox();
            this.PreprocessCheckBox = new System.Windows.Forms.CheckBox();
            this.DirectoryPathLabel = new System.Windows.Forms.Label();
            this.SourceCollectionPathLabel = new System.Windows.Forms.Label();
            this.BuildIndexButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CollectionButton = new System.Windows.Forms.Button();
            this.SearchingBox = new System.Windows.Forms.GroupBox();
            this.AutoParsing = new System.Windows.Forms.Button();
            this.PhraseFormCheckbox = new System.Windows.Forms.CheckBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.QueryEnter = new System.Windows.Forms.TextBox();
            this.RawQueryLabel = new System.Windows.Forms.Label();
            this.folderBuildIndexDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderCollectionDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveInfoDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.SearchedResultView)).BeginInit();
            this.IndexingBox.SuspendLayout();
            this.SearchingBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FinalQueryLabel
            // 
            this.FinalQueryLabel.AutoSize = true;
            this.FinalQueryLabel.Location = new System.Drawing.Point(18, 67);
            this.FinalQueryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FinalQueryLabel.Name = "FinalQueryLabel";
            this.FinalQueryLabel.Size = new System.Drawing.Size(58, 13);
            this.FinalQueryLabel.TabIndex = 1;
            this.FinalQueryLabel.Text = "Final query";
            // 
            // SearchingTimeLabel
            // 
            this.SearchingTimeLabel.AutoSize = true;
            this.SearchingTimeLabel.Location = new System.Drawing.Point(18, 94);
            this.SearchingTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchingTimeLabel.Name = "SearchingTimeLabel";
            this.SearchingTimeLabel.Size = new System.Drawing.Size(80, 13);
            this.SearchingTimeLabel.TabIndex = 2;
            this.SearchingTimeLabel.Text = "Searching time ";
            // 
            // TotalHitsLabel
            // 
            this.TotalHitsLabel.AutoSize = true;
            this.TotalHitsLabel.Location = new System.Drawing.Point(18, 122);
            this.TotalHitsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalHitsLabel.Name = "TotalHitsLabel";
            this.TotalHitsLabel.Size = new System.Drawing.Size(50, 13);
            this.TotalHitsLabel.TabIndex = 5;
            this.TotalHitsLabel.Text = "Total hits";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(156, 389);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 31);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SearchedResultView
            // 
            this.SearchedResultView.AllowUserToAddRows = false;
            this.SearchedResultView.AllowUserToDeleteRows = false;
            this.SearchedResultView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchedResultView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchedResultView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.SearchedResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchedResultView.Location = new System.Drawing.Point(11, 163);
            this.SearchedResultView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchedResultView.MultiSelect = false;
            this.SearchedResultView.Name = "SearchedResultView";
            this.SearchedResultView.ReadOnly = true;
            this.SearchedResultView.RowTemplate.Height = 60;
            this.SearchedResultView.RowTemplate.ReadOnly = true;
            this.SearchedResultView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SearchedResultView.Size = new System.Drawing.Size(889, 220);
            this.SearchedResultView.TabIndex = 8;
            this.SearchedResultView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SearchedResultView_CellContentClick);
            // 
            // DisplayItenButton
            // 
            this.DisplayItenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DisplayItenButton.Location = new System.Drawing.Point(12, 389);
            this.DisplayItenButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DisplayItenButton.Name = "DisplayItenButton";
            this.DisplayItenButton.Size = new System.Drawing.Size(128, 31);
            this.DisplayItenButton.TabIndex = 9;
            this.DisplayItenButton.Text = "Display Selected Item";
            this.DisplayItenButton.UseVisualStyleBackColor = true;
            this.DisplayItenButton.Click += new System.EventHandler(this.DisplayItenButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviousButton.Location = new System.Drawing.Point(745, 389);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(70, 20);
            this.PreviousButton.TabIndex = 10;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(830, 389);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(70, 20);
            this.NextButton.TabIndex = 11;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // IndexingBox
            // 
            this.IndexingBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IndexingBox.AutoSize = true;
            this.IndexingBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IndexingBox.Controls.Add(this.PreprocessCheckBox);
            this.IndexingBox.Controls.Add(this.DirectoryPathLabel);
            this.IndexingBox.Controls.Add(this.SourceCollectionPathLabel);
            this.IndexingBox.Controls.Add(this.BuildIndexButton);
            this.IndexingBox.Controls.Add(this.SubmitButton);
            this.IndexingBox.Controls.Add(this.CollectionButton);
            this.IndexingBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexingBox.Location = new System.Drawing.Point(0, 0);
            this.IndexingBox.Name = "IndexingBox";
            this.IndexingBox.Size = new System.Drawing.Size(392, 151);
            this.IndexingBox.TabIndex = 12;
            this.IndexingBox.TabStop = false;
            this.IndexingBox.Text = "Indexing";
            // 
            // PreprocessCheckBox
            // 
            this.PreprocessCheckBox.AutoSize = true;
            this.PreprocessCheckBox.Location = new System.Drawing.Point(23, 102);
            this.PreprocessCheckBox.Name = "PreprocessCheckBox";
            this.PreprocessCheckBox.Size = new System.Drawing.Size(165, 17);
            this.PreprocessCheckBox.TabIndex = 13;
            this.PreprocessCheckBox.Text = "Preprocessing the information";
            this.PreprocessCheckBox.CheckedChanged += new System.EventHandler(this.PreprocessCheckBox_CheckedChanged);
            // 
            // DirectoryPathLabel
            // 
            this.DirectoryPathLabel.Location = new System.Drawing.Point(211, 23);
            this.DirectoryPathLabel.Name = "DirectoryPathLabel";
            this.DirectoryPathLabel.Size = new System.Drawing.Size(175, 23);
            this.DirectoryPathLabel.TabIndex = 15;
            this.DirectoryPathLabel.Text = "IndexDirectoryPath";
            this.DirectoryPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SourceCollectionPathLabel
            // 
            this.SourceCollectionPathLabel.Location = new System.Drawing.Point(211, 62);
            this.SourceCollectionPathLabel.Name = "SourceCollectionPathLabel";
            this.SourceCollectionPathLabel.Size = new System.Drawing.Size(175, 23);
            this.SourceCollectionPathLabel.TabIndex = 18;
            this.SourceCollectionPathLabel.Text = "SourceCollectionPath";
            this.SourceCollectionPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuildIndexButton
            // 
            this.BuildIndexButton.Location = new System.Drawing.Point(23, 23);
            this.BuildIndexButton.Name = "BuildIndexButton";
            this.BuildIndexButton.Size = new System.Drawing.Size(166, 23);
            this.BuildIndexButton.TabIndex = 14;
            this.BuildIndexButton.Text = "Select Index Directory";
            this.BuildIndexButton.UseVisualStyleBackColor = true;
            this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.AutoSize = true;
            this.SubmitButton.Location = new System.Drawing.Point(261, 98);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 17;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CollectionButton
            // 
            this.CollectionButton.Location = new System.Drawing.Point(24, 62);
            this.CollectionButton.Name = "CollectionButton";
            this.CollectionButton.Size = new System.Drawing.Size(166, 23);
            this.CollectionButton.TabIndex = 16;
            this.CollectionButton.Text = "Select collection path";
            this.CollectionButton.UseVisualStyleBackColor = true;
            this.CollectionButton.Click += new System.EventHandler(this.CollectionButton_Click);
            // 
            // SearchingBox
            // 
            this.SearchingBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchingBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchingBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SearchingBox.Controls.Add(this.AutoParsing);
            this.SearchingBox.Controls.Add(this.PhraseFormCheckbox);
            this.SearchingBox.Controls.Add(this.SearchButton);
            this.SearchingBox.Controls.Add(this.QueryEnter);
            this.SearchingBox.Controls.Add(this.RawQueryLabel);
            this.SearchingBox.Controls.Add(this.FinalQueryLabel);
            this.SearchingBox.Controls.Add(this.SearchingTimeLabel);
            this.SearchingBox.Controls.Add(this.TotalHitsLabel);
            this.SearchingBox.Location = new System.Drawing.Point(392, 0);
            this.SearchingBox.Name = "SearchingBox";
            this.SearchingBox.Size = new System.Drawing.Size(519, 151);
            this.SearchingBox.TabIndex = 13;
            this.SearchingBox.TabStop = false;
            this.SearchingBox.Text = "Searching";
            this.SearchingBox.Enter += new System.EventHandler(this.SearchingBox_Enter);
            // 
            // AutoParsing
            // 
            this.AutoParsing.Location = new System.Drawing.Point(360, 112);
            this.AutoParsing.Name = "AutoParsing";
            this.AutoParsing.Size = new System.Drawing.Size(138, 23);
            this.AutoParsing.TabIndex = 14;
            this.AutoParsing.Text = "Five information needs";
            this.AutoParsing.UseVisualStyleBackColor = true;
            this.AutoParsing.Click += new System.EventHandler(this.AutoParsing_Click);
            // 
            // PhraseFormCheckbox
            // 
            this.PhraseFormCheckbox.AutoSize = true;
            this.PhraseFormCheckbox.Location = new System.Drawing.Point(413, 67);
            this.PhraseFormCheckbox.Name = "PhraseFormCheckbox";
            this.PhraseFormCheckbox.Size = new System.Drawing.Size(85, 17);
            this.PhraseFormCheckbox.TabIndex = 14;
            this.PhraseFormCheckbox.Text = "Phrase Form";
            this.PhraseFormCheckbox.CheckedChanged += new System.EventHandler(this.PhraseFormCheckbox_CheckedChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.AutoSize = true;
            this.SearchButton.Location = new System.Drawing.Point(421, 23);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(77, 23);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // QueryEnter
            // 
            this.QueryEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryEnter.Location = new System.Drawing.Point(116, 25);
            this.QueryEnter.Name = "QueryEnter";
            this.QueryEnter.Size = new System.Drawing.Size(286, 20);
            this.QueryEnter.TabIndex = 7;
            // 
            // RawQueryLabel
            // 
            this.RawQueryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RawQueryLabel.AutoSize = true;
            this.RawQueryLabel.Location = new System.Drawing.Point(18, 28);
            this.RawQueryLabel.Name = "RawQueryLabel";
            this.RawQueryLabel.Size = new System.Drawing.Size(92, 13);
            this.RawQueryLabel.TabIndex = 6;
            this.RawQueryLabel.Text = "Information need: ";
            // 
            // MainSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 432);
            this.Controls.Add(this.SearchingBox);
            this.Controls.Add(this.IndexingBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.DisplayItenButton);
            this.Controls.Add(this.SearchedResultView);
            this.Controls.Add(this.SaveButton);
            this.Name = "MainSearchForm";
            this.Text = "SeachEngine";
            ((System.ComponentModel.ISupportInitialize)(this.SearchedResultView)).EndInit();
            this.IndexingBox.ResumeLayout(false);
            this.IndexingBox.PerformLayout();
            this.SearchingBox.ResumeLayout(false);
            this.SearchingBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FinalQueryLabel;
        private System.Windows.Forms.Label SearchingTimeLabel;
        private System.Windows.Forms.Label TotalHitsLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridView SearchedResultView;
        private System.Windows.Forms.Button DisplayItenButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.GroupBox IndexingBox;
        private System.Windows.Forms.CheckBox PreprocessCheckBox;
        private System.Windows.Forms.Label DirectoryPathLabel;
        private System.Windows.Forms.Label SourceCollectionPathLabel;
        private System.Windows.Forms.Button BuildIndexButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CollectionButton;
        private System.Windows.Forms.GroupBox SearchingBox;
        private System.Windows.Forms.Label RawQueryLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox QueryEnter;
        private System.Windows.Forms.FolderBrowserDialog folderBuildIndexDialog;
        private System.Windows.Forms.FolderBrowserDialog folderCollectionDialog;
        private System.Windows.Forms.CheckBox PhraseFormCheckbox;
        private System.Windows.Forms.Button AutoParsing;
        private System.Windows.Forms.SaveFileDialog saveInfoDialog;
    }
}