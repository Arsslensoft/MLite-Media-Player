using System;
using System.Drawing;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class Black : Form
    {
        public Black()
        {
            InitializeComponent();
            // set Black
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            this.Opacity = 0.6;
        }

        private void Black_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) {
                
            } else {
                
            }
        }
    }
}
