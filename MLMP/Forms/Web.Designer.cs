namespace MLITEMEDIAPLAYER.Forms
{
    partial class Web
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Web));
            this.fileCheckPicBox = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.fileTypeLabel = new System.Windows.Forms.Label();
            this.pasteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileCheckPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileCheckPicBox
            // 
            this.fileCheckPicBox.BackColor = System.Drawing.Color.Transparent;
            this.fileCheckPicBox.Image = global::MLITEMEDIAPLAYER.Properties.Resources.NotExists;
            this.fileCheckPicBox.Location = new System.Drawing.Point(13, 12);
            this.fileCheckPicBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileCheckPicBox.Name = "fileCheckPicBox";
            this.fileCheckPicBox.Size = new System.Drawing.Size(27, 27);
            this.fileCheckPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fileCheckPicBox.TabIndex = 0;
            this.fileCheckPicBox.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.okButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.okButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(13, 46);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 27);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(547, 46);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(84, 27);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Clos&e";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.BackColor = System.Drawing.Color.Transparent;
            this.urlLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.ForeColor = System.Drawing.Color.White;
            this.urlLabel.Location = new System.Drawing.Point(47, 16);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(39, 19);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "&URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.urlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.urlTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextBox.ForeColor = System.Drawing.Color.White;
            this.urlTextBox.Location = new System.Drawing.Point(92, 12);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(478, 27);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoEllipsis = true;
            this.fileTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileTypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileTypeLabel.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTypeLabel.ForeColor = System.Drawing.Color.White;
            this.fileTypeLabel.Location = new System.Drawing.Point(576, 12);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(55, 27);
            this.fileTypeLabel.TabIndex = 9;
            this.fileTypeLabel.Text = "*.*";
            this.fileTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pasteButton
            // 
            this.pasteButton.BackColor = System.Drawing.Color.Transparent;
            this.pasteButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.pasteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.pasteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.pasteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteButton.ForeColor = System.Drawing.Color.White;
            this.pasteButton.Location = new System.Drawing.Point(140, 46);
            this.pasteButton.Margin = new System.Windows.Forms.Padding(4);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(85, 27);
            this.pasteButton.TabIndex = 4;
            this.pasteButton.Text = "&Paste";
            this.pasteButton.UseVisualStyleBackColor = false;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.Transparent;
            this.copyButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.copyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.copyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.ForeColor = System.Drawing.Color.White;
            this.copyButton.Location = new System.Drawing.Point(233, 46);
            this.copyButton.Margin = new System.Windows.Forms.Padding(4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(85, 27);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "&Copy";
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.clearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(326, 46);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(85, 27);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "C&lear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.BackColor = System.Drawing.Color.Transparent;
            this.undoButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.undoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.undoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.ForeColor = System.Drawing.Color.White;
            this.undoButton.Location = new System.Drawing.Point(419, 46);
            this.undoButton.Margin = new System.Windows.Forms.Padding(4);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(85, 27);
            this.undoButton.TabIndex = 7;
            this.undoButton.Text = "&Undo";
            this.undoButton.UseVisualStyleBackColor = false;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // Web
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(644, 82);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.fileTypeLabel);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fileCheckPicBox);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Web";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Play Streaming Media - M-Lite Media Player";
            this.Load += new System.EventHandler(this.Web_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Web_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fileCheckPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fileCheckPicBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label urlLabel;
        internal System.Windows.Forms.Label fileTypeLabel;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button undoButton;
        public System.Windows.Forms.TextBox urlTextBox;
    }
}