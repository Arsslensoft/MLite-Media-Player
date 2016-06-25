namespace MLITEMEDIAPLAYER.Forms
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.warningPicBox = new System.Windows.Forms.PictureBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorSourceTextBox = new System.Windows.Forms.TextBox();
            this.errorSourceLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.errorCodeTextBox = new System.Windows.Forms.TextBox();
            this.errorCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.warningPicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // warningPicBox
            // 
            this.warningPicBox.BackColor = System.Drawing.Color.Transparent;
            this.warningPicBox.Image = ((System.Drawing.Image)(resources.GetObject("warningPicBox.Image")));
            this.warningPicBox.Location = new System.Drawing.Point(12, 12);
            this.warningPicBox.Name = "warningPicBox";
            this.warningPicBox.Size = new System.Drawing.Size(40, 40);
            this.warningPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.warningPicBox.TabIndex = 1;
            this.warningPicBox.TabStop = false;
            // 
            // errorLabel
            // 
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.Location = new System.Drawing.Point(58, 12);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(324, 40);
            this.errorLabel.TabIndex = 2;
            this.errorLabel.Text = "Error";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.okButton.Location = new System.Drawing.Point(155, 233);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 27);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.errorSourceTextBox);
            this.groupBox1.Controls.Add(this.errorSourceLabel);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.descriptionLabel);
            this.groupBox1.Controls.Add(this.errorCodeTextBox);
            this.groupBox1.Controls.Add(this.errorCodeLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 168);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detailed Info";
            // 
            // errorSourceTextBox
            // 
            this.errorSourceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.errorSourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorSourceTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorSourceTextBox.ForeColor = System.Drawing.Color.White;
            this.errorSourceTextBox.Location = new System.Drawing.Point(103, 26);
            this.errorSourceTextBox.Name = "errorSourceTextBox";
            this.errorSourceTextBox.ReadOnly = true;
            this.errorSourceTextBox.Size = new System.Drawing.Size(261, 23);
            this.errorSourceTextBox.TabIndex = 1;
            // 
            // errorSourceLabel
            // 
            this.errorSourceLabel.AutoSize = true;
            this.errorSourceLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorSourceLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorSourceLabel.ForeColor = System.Drawing.Color.White;
            this.errorSourceLabel.Location = new System.Drawing.Point(6, 26);
            this.errorSourceLabel.Name = "errorSourceLabel";
            this.errorSourceLabel.Size = new System.Drawing.Size(91, 19);
            this.errorSourceLabel.TabIndex = 0;
            this.errorSourceLabel.Text = "Error source:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.ForeColor = System.Drawing.Color.White;
            this.descriptionTextBox.Location = new System.Drawing.Point(6, 103);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(358, 58);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 81);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(87, 19);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description:";
            // 
            // errorCodeTextBox
            // 
            this.errorCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.errorCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorCodeTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCodeTextBox.ForeColor = System.Drawing.Color.White;
            this.errorCodeTextBox.Location = new System.Drawing.Point(103, 55);
            this.errorCodeTextBox.Name = "errorCodeTextBox";
            this.errorCodeTextBox.ReadOnly = true;
            this.errorCodeTextBox.Size = new System.Drawing.Size(261, 23);
            this.errorCodeTextBox.TabIndex = 3;
            // 
            // errorCodeLabel
            // 
            this.errorCodeLabel.AutoSize = true;
            this.errorCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorCodeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCodeLabel.ForeColor = System.Drawing.Color.White;
            this.errorCodeLabel.Location = new System.Drawing.Point(6, 55);
            this.errorCodeLabel.Name = "errorCodeLabel";
            this.errorCodeLabel.Size = new System.Drawing.Size(79, 19);
            this.errorCodeLabel.TabIndex = 2;
            this.errorCodeLabel.Text = "Error code:";
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.warningPicBox);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M-Lite Media Player - Error";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warningPicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox warningPicBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox errorCodeTextBox;
        internal System.Windows.Forms.Label errorCodeLabel;
        internal System.Windows.Forms.TextBox descriptionTextBox;
        internal System.Windows.Forms.Label descriptionLabel;
        internal System.Windows.Forms.Label errorSourceLabel;
        internal System.Windows.Forms.TextBox errorSourceTextBox;
    }
}