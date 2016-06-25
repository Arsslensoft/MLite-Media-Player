namespace MLITEMEDIAPLAYER.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.versionLabel = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.creditsTextBox = new System.Windows.Forms.RichTextBox();
            this.nnpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.shortcutKeysListBox = new System.Windows.Forms.ListBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ForeColor = System.Drawing.Color.White;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 337);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(91)))));
            this.tabPage1.Controls.Add(this.versionLabel);
            this.tabPage1.Controls.Add(this.GroupBox1);
            this.tabPage1.Controls.Add(this.nnpLinkLabel);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "About";
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPages_Paint);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(5, 283);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(93, 20);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Version: 2.0";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.creditsTextBox);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.White;
            this.GroupBox1.Location = new System.Drawing.Point(6, 102);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(334, 178);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // creditsTextBox
            // 
            this.creditsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.creditsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creditsTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.creditsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsTextBox.ForeColor = System.Drawing.Color.White;
            this.creditsTextBox.Location = new System.Drawing.Point(3, 6);
            this.creditsTextBox.Name = "creditsTextBox";
            this.creditsTextBox.ReadOnly = true;
            this.creditsTextBox.Size = new System.Drawing.Size(328, 169);
            this.creditsTextBox.TabIndex = 0;
            this.creditsTextBox.Text = resources.GetString("creditsTextBox.Text");
            // 
            // nnpLinkLabel
            // 
            this.nnpLinkLabel.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.nnpLinkLabel.AutoSize = true;
            this.nnpLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.nnpLinkLabel.ForeColor = System.Drawing.Color.White;
            this.nnpLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.nnpLinkLabel.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.nnpLinkLabel.Location = new System.Drawing.Point(255, 283);
            this.nnpLinkLabel.Name = "nnpLinkLabel";
            this.nnpLinkLabel.Size = new System.Drawing.Size(89, 20);
            this.nnpLinkLabel.TabIndex = 2;
            this.nnpLinkLabel.TabStop = true;
            this.nnpLinkLabel.Text = "Arsslensoft";
            this.nnpLinkLabel.VisitedLinkColor = System.Drawing.Color.DarkOrchid;
            this.nnpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nnpLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ForeColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::MLITEMEDIAPLAYER.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.shortcutKeysListBox);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shortcut Keys";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // shortcutKeysListBox
            // 
            this.shortcutKeysListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.shortcutKeysListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shortcutKeysListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutKeysListBox.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.shortcutKeysListBox.ForeColor = System.Drawing.Color.White;
            this.shortcutKeysListBox.FormattingEnabled = true;
            this.shortcutKeysListBox.HorizontalScrollbar = true;
            this.shortcutKeysListBox.IntegralHeight = false;
            this.shortcutKeysListBox.ItemHeight = 15;
            this.shortcutKeysListBox.Items.AddRange(new object[] {
            "~ Playback Controls ~",
            "Spacebar: Pause/Play",
            "Scroll Up: Increase Volume",
            "Scroll Down: Decrease Volume",
            "Enter: Full Screen",
            "Alt+Enter: Exit Full Screen",
            "",
            "~ Next/Previous File ~",
            "Ctrl+Left: Play Previous File",
            "Ctrl+Right: Play Next File",
            "",
            "~ Volume ~",
            "Ctrl+Up: Increase Volume",
            "Ctrl+Down: Decrease Volume",
            "",
            "~ Quick Action Controls ~",
            "Shift Key: Say Media Name (\"[Title] by [Artist]\" or \"[File Name]\")"});
            this.shortcutKeysListBox.Location = new System.Drawing.Point(3, 3);
            this.shortcutKeysListBox.Name = "shortcutKeysListBox";
            this.shortcutKeysListBox.ScrollAlwaysVisible = true;
            this.shortcutKeysListBox.Size = new System.Drawing.Size(364, 298);
            this.shortcutKeysListBox.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(142, 354);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(396, 408);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About M-lite Media Player";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel nnpLinkLabel;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ListBox shortcutKeysListBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.RichTextBox creditsTextBox;
    }
}