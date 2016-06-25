// Custom InputBox
// by Joshua Park
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class InputBox : DevComponents.DotNetBar.Metro.MetroForm
    {
        public InputBox(string Message, string Title, string defaultEnteredText)
        {
            InitializeComponent();
            // set info
            this.Text = Title;
            messageLabel.Text = Message;
            inputTextBox.Text = defaultEnteredText;
            // set focus
            inputTextBox.Focus();
            inputTextBox.SelectAll();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        public string enteredText {
            get { return inputTextBox.Text; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inputTextBox.TextLength > 0)
                okButton.Enabled = true;
            else
                okButton.Enabled = false;
        }
    }
}
