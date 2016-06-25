using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class SaveSnapshot : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SaveSnapshot()
        {
            InitializeComponent();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(mainPanel.ClientRectangle, Color.FromArgb(255, 27, 27, 27), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, mainPanel.ClientRectangle);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void snapshotPicBox_SizeChanged(object sender, EventArgs e)
        {
            if (snapshotPicBox.Width <= snapshotPicBox.Image.Width | snapshotPicBox.Height <= snapshotPicBox.Image.Height)
                snapshotPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            else
                snapshotPicBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
