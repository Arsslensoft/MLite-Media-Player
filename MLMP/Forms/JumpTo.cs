using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class JumpTo : DevComponents.DotNetBar.Metro.MetroForm
    {
        public double totalSec, currentSec;

        public double newTime {
            get {
                int hHour, mMin, sSec;
                int.TryParse(hourTextBox.Text, out hHour);
                int.TryParse(minTextBox.Text, out mMin);
                int.TryParse(secTextBox.Text, out sSec);
                return sSec + (mMin * 60) + (hHour * 3600);
            }
        }

        #region currentControlLabel Code
        private void hourTextBox_MouseEnter(object sender, EventArgs e)
        {
            currentControlLabel.Text = "Hour";
        }

        private void minTextBox_MouseEnter(object sender, EventArgs e)
        {
            currentControlLabel.Text = "Minute";
        }

        private void secTextBox_MouseEnter(object sender, EventArgs e)
        {
            currentControlLabel.Text = "Second";
        }

        private void goButton_MouseEnter(object sender, EventArgs e)
        {
            currentControlLabel.Text = "Warp!!";
        }

        private void textBoxLeave_MouseLeave(object sender, EventArgs e)
        {
            currentControlLabel.Text = string.Empty;
        }
        #endregion

        public JumpTo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void JumpTo_Load(object sender, EventArgs e)
        {
            int hHour = (int)(totalSec / 3600);
            int mMin = (int)((totalSec % 3600) / 60);
            int sSec = (int)((totalSec % 3600) % 60);

            int cHour = (int)(currentSec / 3600);
            int cMin = (int)((currentSec % 3600) / 60);
            int cSec = (int)((currentSec % 3600) % 60);

            totalTimeLabel.Text = hHour.ToString("00") + ":" + mMin.ToString("00") + ":" + sSec.ToString("00");

            if (hHour >= 1) {
                // hour, min, sec
                hourTextBox.Enabled = true;
                minTextBox.Enabled = true;

                hourTextBox.Text = cHour.ToString();
                minTextBox.Text = cMin.ToString();
                secTextBox.Text = cSec.ToString();
            } else if (mMin >= 1) {
                // min, sec
                hourTextBox.Enabled = false;
                minTextBox.Enabled = true;

                hourTextBox.Text = string.Empty;
                minTextBox.Text = cMin.ToString();
                secTextBox.Text = cSec.ToString();
            } else {
                // seconds only
                hourTextBox.Enabled = false;
                minTextBox.Enabled = false;

                hourTextBox.Text = string.Empty;
                minTextBox.Text = string.Empty;
                secTextBox.Text = cSec.ToString();
            }
        }

        private void JumpTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckTimes_TextChanged(object sender, EventArgs e)
        {
            int hHour, mMin, sSec;
            int.TryParse(hourTextBox.Text, out hHour);
            int.TryParse(minTextBox.Text, out mMin);
            int.TryParse(secTextBox.Text, out sSec);
            double dTotal = sSec + (mMin * 60) + (hHour * 3600);

            if (dTotal < totalSec) {
                timeCheckPicBox.Image = Properties.Resources.Exists;
                goButton.Enabled = true;
            } else {
                timeCheckPicBox.Image = Properties.Resources.NotExists;
                goButton.Enabled = false;
            }
        }
    }
}