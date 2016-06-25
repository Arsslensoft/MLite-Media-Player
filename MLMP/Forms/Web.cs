using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class Web : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Web()
        {
            InitializeComponent();
        }

        public string URL = string.Empty;

        #region Paste, Copy, Clear, Undo, Close Buttons
        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text)) {
                urlTextBox.Text = Clipboard.GetText();
                urlTextBox.Focus();
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (urlTextBox.SelectionLength == 0) urlTextBox.SelectAll();
            urlTextBox.Copy();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            urlTextBox.Text = string.Empty;
            urlTextBox.Focus();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (urlTextBox.CanUndo) {
                urlTextBox.Focus();
                urlTextBox.Undo();
            } else {
                MessageBox.Show("Cannot undo action!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void Web_Load(object sender, EventArgs e)
        {
            urlTextBox.Text = URL;
            urlTextBox.SelectAll();
            urlTextBox.Focus();
        }

        private void Web_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) openURL();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            openURL();
        }

        private void openURL() {
            if (urlTextBox.Text == URL) {
                if (MessageBox.Show("You are already playing \"" + System.IO.Path.GetFileName(URL) + "\"!\nDo you still want to open this file?", "Already Playing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } else {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (urlTextBox.Text != string.Empty) {
                string fileType = System.IO.Path.GetExtension(urlTextBox.Text).ToUpper();
                fileTypeLabel.Text = (fileType != string.Empty) ? fileType : "?";

                if (System.IO.File.Exists(urlTextBox.Text)) {
                    // local file
                    fileCheckPicBox.Image = Properties.Resources.Exists;
                    okButton.Enabled = true;
                } else if (Functions.validateURL(urlTextBox.Text)){
                    // web file
                    fileCheckPicBox.Image = Properties.Resources.Exists;
                    okButton.Enabled = true;
                } else {
                    fileTypeLabel.Text = "*.*";
                    fileCheckPicBox.Image = Properties.Resources.NotExists;
                    okButton.Enabled = false;
                }
            } else {
                fileTypeLabel.Text = "*.*";
                fileCheckPicBox.Image = Properties.Resources.NotExists;
                okButton.Enabled = false;
            }
        }
    }
}
