using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class About : DevComponents.DotNetBar.Metro.MetroForm
    {
        public About()
        {
            InitializeComponent();
            versionLabel.Text = "Version: " + Application.ProductVersion;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void tabPages_Paint(object sender, PaintEventArgs e)
        {
            TabPage newSender = (TabPage)sender;
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(newSender.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void nnpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.arsslensoft.fi5.us");
        }

    }
}
