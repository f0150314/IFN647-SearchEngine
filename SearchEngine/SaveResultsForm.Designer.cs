namespace SearchEngine
{
    partial class SaveResultsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.topicEnter = new System.Windows.Forms.TextBox();
            this.SaveDocumentButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Topic ID:";
            // 
            // topicEnter
            // 
            this.topicEnter.Location = new System.Drawing.Point(83, 28);
            this.topicEnter.Name = "topicEnter";
            this.topicEnter.Size = new System.Drawing.Size(114, 20);
            this.topicEnter.TabIndex = 4;
            // 
            // SaveDocumentButton
            // 
            this.SaveDocumentButton.Location = new System.Drawing.Point(211, 26);
            this.SaveDocumentButton.Name = "SaveDocumentButton";
            this.SaveDocumentButton.Size = new System.Drawing.Size(83, 23);
            this.SaveDocumentButton.TabIndex = 5;
            this.SaveDocumentButton.Text = "Save";
            this.SaveDocumentButton.UseVisualStyleBackColor = true;
            this.SaveDocumentButton.Click += new System.EventHandler(this.SaveDocumentButton_Click);
            // 
            // SaveDocumentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 73);
            this.Controls.Add(this.SaveDocumentButton);
            this.Controls.Add(this.topicEnter);
            this.Controls.Add(this.label1);
            this.Name = "SaveDocumentWindow";
            this.Text = "Please specify topic identification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox topicEnter;
        private System.Windows.Forms.Button SaveDocumentButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}