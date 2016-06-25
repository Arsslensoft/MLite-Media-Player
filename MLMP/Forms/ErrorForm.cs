using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class ErrorForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public WMPLib.IWMPErrorItem errorItem;
        public string URL;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            // error source
            errorSourceTextBox.Text = System.IO.Path.GetFileName(URL);
            // error code
            errorCodeTextBox.Text = errorItem.errorCode.ToString("X");
            // error description
            descriptionTextBox.Text = errorItem.errorDescription;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
