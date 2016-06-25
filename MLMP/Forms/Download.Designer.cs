namespace MLITEMEDIAPLAYER.Forms
{
    partial class Download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Download));
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.closeCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadBar = new System.Windows.Forms.ProgressBar();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.saveToLabel = new System.Windows.Forms.Label();
            this.saveToTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.fileSizeTextBox = new System.Windows.Forms.TextBox();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.infoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(450, 214);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 27);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(3, 6);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(518, 19);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Starting, this may take a while...";
            // 
            // closeCheckBox
            // 
            this.closeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeCheckBox.AutoSize = true;
            this.closeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.closeCheckBox.Location = new System.Drawing.Point(12, 216);
            this.closeCheckBox.Name = "closeCheckBox";
            this.closeCheckBox.Size = new System.Drawing.Size(223, 24);
            this.closeCheckBox.TabIndex = 1;
            this.closeCheckBox.Text = "Close dialog after download";
            this.closeCheckBox.UseVisualStyleBackColor = false;
            // 
            // downloadBar
            // 
            this.downloadBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadBar.Location = new System.Drawing.Point(12, 187);
            this.downloadBar.Name = "downloadBar";
            this.downloadBar.Size = new System.Drawing.Size(524, 20);
            this.downloadBar.TabIndex = 5;
            // 
            // openFolderButton
            // 
            this.openFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openFolderButton.BackColor = System.Drawing.Color.Transparent;
            this.openFolderButton.Enabled = false;
            this.openFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.openFolderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.openFolderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.openFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFolderButton.ForeColor = System.Drawing.Color.White;
            this.openFolderButton.Location = new System.Drawing.Point(342, 214);
            this.openFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(100, 27);
            this.openFolderButton.TabIndex = 3;
            this.openFolderButton.Text = "&Open Folder";
            this.openFolderButton.UseVisualStyleBackColor = false;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.BackColor = System.Drawing.Color.Transparent;
            this.openButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.openButton.Enabled = false;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.openButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.openButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(249, 214);
            this.openButton.Margin = new System.Windows.Forms.Padding(4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(85, 27);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "&Open";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.infoGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.infoGroupBox.Controls.Add(this.saveToLabel);
            this.infoGroupBox.Controls.Add(this.saveToTextBox);
            this.infoGroupBox.Controls.Add(this.fileNameTextBox);
            this.infoGroupBox.Controls.Add(this.fileNameLabel);
            this.infoGroupBox.Controls.Add(this.speedTextBox);
            this.infoGroupBox.Controls.Add(this.speedLabel);
            this.infoGroupBox.Controls.Add(this.fileSizeTextBox);
            this.infoGroupBox.Controls.Add(this.fileSizeLabel);
            this.infoGroupBox.Controls.Add(this.statusLabel);
            this.infoGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(524, 169);
            this.infoGroupBox.TabIndex = 4;
            this.infoGroupBox.TabStop = false;
            // 
            // saveToLabel
            // 
            this.saveToLabel.AutoSize = true;
            this.saveToLabel.BackColor = System.Drawing.Color.Transparent;
            this.saveToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToLabel.Location = new System.Drawing.Point(6, 114);
            this.saveToLabel.Name = "saveToLabel";
            this.saveToLabel.Size = new System.Drawing.Size(83, 20);
            this.saveToLabel.TabIndex = 7;
            this.saveToLabel.Text = "Saving To:";
            // 
            // saveToTextBox
            // 
            this.saveToTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.saveToTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saveToTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToTextBox.ForeColor = System.Drawing.Color.White;
            this.saveToTextBox.Location = new System.Drawing.Point(133, 115);
            this.saveToTextBox.Multiline = true;
            this.saveToTextBox.Name = "saveToTextBox";
            this.saveToTextBox.ReadOnly = true;
            this.saveToTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.saveToTextBox.Size = new System.Drawing.Size(381, 46);
            this.saveToTextBox.TabIndex = 8;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameTextBox.ForeColor = System.Drawing.Color.White;
            this.fileNameTextBox.Location = new System.Drawing.Point(133, 28);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(381, 22);
            this.fileNameTextBox.TabIndex = 2;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(6, 28);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(84, 20);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "File Name:";
            // 
            // speedTextBox
            // 
            this.speedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.speedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedTextBox.ForeColor = System.Drawing.Color.White;
            this.speedTextBox.Location = new System.Drawing.Point(133, 86);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.ReadOnly = true;
            this.speedTextBox.Size = new System.Drawing.Size(381, 22);
            this.speedTextBox.TabIndex = 6;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.Location = new System.Drawing.Point(6, 86);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(135, 20);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Download Speed:";
            // 
            // fileSizeTextBox
            // 
            this.fileSizeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.fileSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSizeTextBox.ForeColor = System.Drawing.Color.White;
            this.fileSizeTextBox.Location = new System.Drawing.Point(133, 57);
            this.fileSizeTextBox.Name = "fileSizeTextBox";
            this.fileSizeTextBox.ReadOnly = true;
            this.fileSizeTextBox.Size = new System.Drawing.Size(381, 22);
            this.fileSizeTextBox.TabIndex = 4;
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSizeLabel.Location = new System.Drawing.Point(6, 57);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(73, 20);
            this.fileSizeLabel.TabIndex = 3;
            this.fileSizeLabel.Text = "File Size:";
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(548, 254);
            this.ControlBox = false;
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.downloadBar);
            this.Controls.Add(this.closeCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Download";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0% - Downloading...";
            this.Load += new System.EventHandler(this.Download_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Download_FormClosing);
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox closeCheckBox;
        private System.Windows.Forms.ProgressBar downloadBar;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.Label fileSizeLabel;
        internal System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label speedLabel;
        internal System.Windows.Forms.TextBox fileSizeTextBox;
        internal System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label saveToLabel;
        internal System.Windows.Forms.TextBox saveToTextBox;
    }
}