namespace MLITEMEDIAPLAYER.Forms
{
    partial class JumpTo
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
            this.timePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.hourTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.secTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.timeCheckPicBox = new System.Windows.Forms.PictureBox();
            this.goButton = new System.Windows.Forms.Button();
            this.currentControlLabel = new System.Windows.Forms.Label();
            this.timePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeCheckPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timePanel
            // 
            this.timePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.timePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timePanel.Controls.Add(this.label2);
            this.timePanel.Controls.Add(this.hourTextBox);
            this.timePanel.Controls.Add(this.minTextBox);
            this.timePanel.Controls.Add(this.label1);
            this.timePanel.Controls.Add(this.secTextBox);
            this.timePanel.Location = new System.Drawing.Point(47, 40);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(178, 27);
            this.timePanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(114, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // hourTextBox
            // 
            this.hourTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.hourTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hourTextBox.ForeColor = System.Drawing.Color.White;
            this.hourTextBox.Location = new System.Drawing.Point(3, 2);
            this.hourTextBox.Name = "hourTextBox";
            this.hourTextBox.Size = new System.Drawing.Size(40, 20);
            this.hourTextBox.TabIndex = 0;
            this.hourTextBox.Text = "00";
            this.hourTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hourTextBox.TextChanged += new System.EventHandler(this.CheckTimes_TextChanged);
            this.hourTextBox.MouseLeave += new System.EventHandler(this.textBoxLeave_MouseLeave);
            this.hourTextBox.MouseEnter += new System.EventHandler(this.hourTextBox_MouseEnter);
            // 
            // minTextBox
            // 
            this.minTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.minTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minTextBox.ForeColor = System.Drawing.Color.White;
            this.minTextBox.Location = new System.Drawing.Point(68, 2);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(40, 20);
            this.minTextBox.TabIndex = 2;
            this.minTextBox.Text = "00";
            this.minTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minTextBox.TextChanged += new System.EventHandler(this.CheckTimes_TextChanged);
            this.minTextBox.MouseLeave += new System.EventHandler(this.textBoxLeave_MouseLeave);
            this.minTextBox.MouseEnter += new System.EventHandler(this.minTextBox_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(49, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            // 
            // secTextBox
            // 
            this.secTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.secTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secTextBox.ForeColor = System.Drawing.Color.White;
            this.secTextBox.Location = new System.Drawing.Point(133, 2);
            this.secTextBox.Name = "secTextBox";
            this.secTextBox.Size = new System.Drawing.Size(40, 20);
            this.secTextBox.TabIndex = 4;
            this.secTextBox.Text = "00";
            this.secTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.secTextBox.TextChanged += new System.EventHandler(this.CheckTimes_TextChanged);
            this.secTextBox.MouseLeave += new System.EventHandler(this.textBoxLeave_MouseLeave);
            this.secTextBox.MouseEnter += new System.EventHandler(this.secTextBox_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Time:";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalTimeLabel.Location = new System.Drawing.Point(99, 9);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(126, 27);
            this.totalTimeLabel.TabIndex = 3;
            this.totalTimeLabel.Text = "00:00:00";
            this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeCheckPicBox
            // 
            this.timeCheckPicBox.BackColor = System.Drawing.Color.Transparent;
            this.timeCheckPicBox.Image = global::MLITEMEDIAPLAYER.Properties.Resources.NotExists;
            this.timeCheckPicBox.Location = new System.Drawing.Point(13, 40);
            this.timeCheckPicBox.Margin = new System.Windows.Forms.Padding(4);
            this.timeCheckPicBox.Name = "timeCheckPicBox";
            this.timeCheckPicBox.Size = new System.Drawing.Size(27, 27);
            this.timeCheckPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.timeCheckPicBox.TabIndex = 4;
            this.timeCheckPicBox.TabStop = false;
            // 
            // goButton
            // 
            this.goButton.BackColor = System.Drawing.Color.Transparent;
            this.goButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.goButton.Enabled = false;
            this.goButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.goButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.goButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.ForeColor = System.Drawing.Color.White;
            this.goButton.Location = new System.Drawing.Point(232, 40);
            this.goButton.Margin = new System.Windows.Forms.Padding(4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(70, 27);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "&Go";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.MouseLeave += new System.EventHandler(this.textBoxLeave_MouseLeave);
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            this.goButton.MouseEnter += new System.EventHandler(this.goButton_MouseEnter);
            // 
            // currentControlLabel
            // 
            this.currentControlLabel.AutoEllipsis = true;
            this.currentControlLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentControlLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentControlLabel.Location = new System.Drawing.Point(232, 9);
            this.currentControlLabel.Name = "currentControlLabel";
            this.currentControlLabel.Size = new System.Drawing.Size(70, 27);
            this.currentControlLabel.TabIndex = 4;
            this.currentControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JumpTo
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(314, 77);
            this.Controls.Add(this.currentControlLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.timeCheckPicBox);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePanel);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JumpTo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jump To Time";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.JumpTo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JumpTo_KeyDown);
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeCheckPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hourTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox secTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.PictureBox timeCheckPicBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label currentControlLabel;
    }
}