using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HundredMilesSoftware.UltraID3Lib;
using System.Drawing.Imaging;
using DevComponents.DotNetBar.Metro;
using System.IO;

namespace MLITEMEDIAPLAYER {
    public partial class mainForm : MetroForm {
        // used to get the virtual keys
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        #region Global Objects
        // get available wmp controls
        private WMPLib.IWMPControls3 controls;
        // fullScreenToolStripMenuItem_Click
        private bool showFullScreenDialog = true;
        // file's playlist index
        private int playlistIndex = -1;
        // get ID3 Tags
        private UltraID3 ID3tag = new UltraID3();
        // seekBar MouseDown
        private bool seekMouseDown = false;
        // hasAlbumPicture
        private bool hasAlbumPicture = false;
        // is music file
        private bool isMusicFile = false;
        // lastFile
        private bool firstFile = true;
        private string tempURL = string.Empty;
        // mediaEnded
        private bool mediaEnded = false;
        // askDelete
        private bool askDelete = true;
        // changePlaylist (if not shuffled nor reordered)
        private bool changePlaylist = true;
        // startDragDrop
        private bool startDragDrop = false;
        // speech synthesizer
       
        public string URL {
            get { return WMP.URL; }
        }
        #endregion
        public mainForm() {
            InitializeComponent();
            // set minimum size



            mainMenuStripX.Renderer = new Office2007Renderer.Office2007Renderer();
            notifyIconContextMenuStrip.Renderer = new Office2007Renderer.Office2007Renderer();
            this.MinimumSize = new Size(this.Width, SystemInformation.VerticalResizeBorderThickness * 2 + SystemInformation.CaptionHeight + mainMenuStripX.Height + seekPanel.Height + controlPanel.Height);
            // Embbeding Font (LCD)
            string fontFile = (Application.StartupPath + "\\LCD.ttf");
            if (System.IO.File.Exists(fontFile) == false) System.IO.File.WriteAllBytes(fontFile, Properties.Resources.LCD);
            Font fontLCD = CreateFont(fontFile, FontStyle.Bold, 11.25f, GraphicsUnit.Point);
            durationLabel.Font = fontLCD; timeLeftLabel.Font = fontLCD;
            // WMP settings
            controls = (WMPLib.IWMPControls3)WMP.Ctlcontrols; // get available controls
            WMP.Ctlenabled = true;
            WMP.enableContextMenu = false;
            WMP.stretchToFit = true;
            WMP.uiMode = "none";
            WMP.Refresh();
            // hide playlist
            mainSplitContainer.Panel2Collapsed = true;
            loadSettings(); // load settings
            this.Update(); // refresh
        }

        #region Snap-To-Border Settings
        private const int mSnapOffset = 10; // pixels
        private const int WM_WINDOWPOSCHANGING = 0x46;
        #endregion
        
        #region Snap-to-Border Code + Minimize to Tray Code
        // snap to border constants
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS{
            public IntPtr hwnd; public IntPtr hwndInsertAfter;
            public int x; public int y; public int cx; public int cy; public int flags;
        }
        // minimize to notification area constants
        const Int32 WM_SYSCOMMAND = 0x112;
        const Int32 SC_MINIMIZE = 0xf020;
        //const Int32 SC_RESTORE = 0xf120;

        protected override void WndProc(ref Message m) {
            // Listen for operating system messages
          if(m.Msg ==WM_WINDOWPOSCHANGING)
          {
                    // Snap to desktop border
                    SnapToDesktopBorder(this, m.LParam, 0);
          }
          else if(m.Msg ==  WM_SYSCOMMAND)
          {
                    if (m.WParam.ToInt32() == SC_MINIMIZE) {
                        // mainForm minimize
                        Black.Visible = false;
                        if (minimizeToSystemTrayToolStripMenuItem.Enabled && minimizeToSystemTrayToolStripMenuItem.Checked)
                            toggleToTaskbar(true);
                    }
          }
          else if(m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
          {
                    ShowWindow();
          }
           
            base.WndProc(ref m);
        }

       
        public void ShowWindow()
        {
            try
            {
                if (WindowState == FormWindowState.Minimized)
                {

                    this.Show();
                    this.WindowState = FormWindowState.Maximized;
           
                }
                else
                {
                    WinApi.ShowToFront(this.Handle);
                }

            }
            catch
            {

            }
            try
            {
                if (File.Exists(Application.StartupPath + @"\ARGS.t"))
                {

                       try {
                    changePlaylist = true;
                    WMP.URL = File.ReadAllLines(Application.StartupPath + @"\ARGS.t")[1];
                    WMP.Ctlcontrols.play();
                } catch (Exception ex) {
                    WMP.Ctlcontrols.stop();
                    durationTimer.Enabled = false;
                    MessageBox.Show("An unexpected error occured while trying to open the video. Please make sure that the media you have selected is supported by your system.\n(Advanced Info: " + ex.Message + ')', "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    File.Delete(Application.StartupPath + @"\ARGS.t");
                }
            }
            catch
            {
            }
        }
        private static void SnapToDesktopBorder(Form clientForm, IntPtr LParam, int widthAdjustment) {
            if (clientForm == null) {
                // Satisfies rule: Validate parameters
                throw new ArgumentNullException("clientForm");
            }

            // Snap client to the top, left, bottom or right desktop border
            // as the form is moved near that border.

            try {
                // Marshal the LPARAM value which is a WINDOWPOS struct
                WINDOWPOS NewPosition = new WINDOWPOS();
                NewPosition = (WINDOWPOS)System.Runtime.InteropServices.Marshal.PtrToStructure(LParam, typeof(WINDOWPOS));

                if (NewPosition.y == 0 || NewPosition.x == 0) {
                    // Nothing to do!
                    return;
                }

                // Adjust the client size for borders and caption bar
                Rectangle ClientRect = clientForm.RectangleToScreen(clientForm.ClientRectangle);
                ClientRect.Width += SystemInformation.FrameBorderSize.Width - widthAdjustment;
                ClientRect.Height += (SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight);

                // Now get the screen working area (without taskbar)
                Rectangle WorkingRect = Screen.GetWorkingArea(clientForm.ClientRectangle);

                // Left border
                if (NewPosition.x >= WorkingRect.X - mSnapOffset && NewPosition.x <= WorkingRect.X + mSnapOffset)
                    NewPosition.x = WorkingRect.X;

                // Get screen bounds and taskbar height
                // (when taskbar is horizontal)
                Rectangle ScreenRect = Screen.GetBounds(Screen.PrimaryScreen.Bounds);
                int TaskbarHeight = ScreenRect.Height - WorkingRect.Height;

                // Top border (check if taskbar is on top
                // or bottom via WorkingRect.Y)

                if (NewPosition.y >= -mSnapOffset && (WorkingRect.Y > 0 && NewPosition.y <= (TaskbarHeight + mSnapOffset)) || (WorkingRect.Y <= 0 && NewPosition.y <= (mSnapOffset))) {
                    if (TaskbarHeight > 0) {
                        // Horizontal Taskbar
                        NewPosition.y = WorkingRect.Y;
                    }
                    else{
                        // Vertical Taskbar
                        NewPosition.y = 0;
                    }
                }

                // Right border
                if (NewPosition.x + ClientRect.Width <= WorkingRect.Right + mSnapOffset && NewPosition.x + ClientRect.Width >= WorkingRect.Right - mSnapOffset)
                    NewPosition.x = WorkingRect.Right - (ClientRect.Width + SystemInformation.FrameBorderSize.Width);

                // Bottom border
                if (NewPosition.y + ClientRect.Height <= WorkingRect.Bottom + mSnapOffset && NewPosition.y + ClientRect.Height >= WorkingRect.Bottom - mSnapOffset)
                    NewPosition.y = WorkingRect.Bottom - (ClientRect.Height + SystemInformation.FrameBorderSize.Height);

                // Marshal it back
                System.Runtime.InteropServices.Marshal.StructureToPtr(NewPosition, LParam, true);
            }
            catch {
            }
        }
        #endregion
        
        #region * Load Form Classes *
        // load forms
        private Forms.About About = new Forms.About();
        private Forms.Black Black = new Forms.Black();
        // Download form loaded at saveMediaAsToolStripMenuItem_Click()
        private Forms.ErrorForm ErrorForm = new Forms.ErrorForm();
        private Forms.JumpTo JumpTo = new Forms.JumpTo();
        private Forms.MediaInfo MediaInfo = new Forms.MediaInfo();
        private Forms.SaveSnapshot SaveSnapshot = new Forms.SaveSnapshot();
        private Forms.Web Web = new Forms.Web();
        #endregion
        #region Draggable Form
        private void DraggableWindow_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Control control = (Control)sender;
                control.Capture = false;
                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0xa1;
                const int HTCAPTION = 2;
                Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
        #endregion
        #region Drag & Drop Files
        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileDirs = (string[])e.Data.GetData(DataFormats.FileDrop);
            string fileDir = fileDirs.GetValue(0).ToString();

            if (System.IO.File.Exists(fileDir) == true)
                WMP.URL = fileDir;
            else {
                MessageBox.Show('\"' + System.IO.Path.GetFileName(fileDir) + "\" does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Embbed Font Code
        private static System.Drawing.Text.PrivateFontCollection fonts;
        private static System.Drawing.FontFamily NewFont_FF;

        private System.Drawing.Font CreateFont(string name, System.Drawing.FontStyle style, float size, System.Drawing.GraphicsUnit unit) {
            //Create a new font collection
            fonts = new System.Drawing.Text.PrivateFontCollection();
            //Add the font file to the new font
            //"name" is the qualified path to your font file
            fonts.AddFontFile(name);
            //Retrieve your new font
            NewFont_FF = fonts.Families[0];

            return new System.Drawing.Font(NewFont_FF, size, style, unit);
        }
        #endregion
        #region Gradient Paint
        private void seekPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(controlPanel.ClientRectangle, Color.FromArgb(255, 30, 30, 30), Color.FromArgb(255, 27, 27, 27), LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, controlPanel.ClientRectangle);
        }

        private void controlPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(controlPanel.ClientRectangle, Color.FromArgb(255, 27, 27, 27), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, controlPanel.ClientRectangle);
        }
        #endregion

        #region File
        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Black.Visible == false)
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            else
                MessageBox.Show("You must un-dim the desktop in order to launch a new instance of M-Lite Media Player.", "Uncheck Dim Desktop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Web.URL = URL;
            if (Web.ShowDialog(this) == DialogResult.OK) {
                WMP.URL = Web.urlTextBox.Text;
            }
        }

        private void driveDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDrive("D");
        }

        private void driveEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDrive("E");
        }

        private void specifyDriveLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputBox = new Forms.InputBox("Type in the drive letter that the CD/DVD disc is in:", "Specify Drive Letter", "D");
            if (inputBox.ShowDialog(this) == DialogResult.OK)
                openDrive(inputBox.enteredText.ToUpper());
        }

        private void openDrive(string driveLetter) {
            if (System.IO.File.Exists(driveLetter + ":\\VIDEO_TS\\VIDEO_TS.vob")) {
                WMP.URL = driveLetter + ":\\VIDEO_TS\\VIDEO_TS.vob";
            } else if (System.IO.File.Exists(driveLetter + ":\\Track01.cda")) {
                WMP.URL = driveLetter + ":\\Track01.cda";
            } else {
                MessageBox.Show("Error playing the disc in drive \"" + driveLetter + "\".", "Cannot Play Disc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openLocationFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clipText = Clipboard.GetText();
            if (System.IO.File.Exists(clipText) || Functions.validateURL(clipText))
                WMP.URL = clipText;
            else
                MessageBox.Show("The location \"" + clipText + "\" cannot be opened.", "Error Opening Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void openLastFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.URL = Properties.Settings.Default.LastFile;
        }

        private void saveMediaAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.FileName = System.IO.Path.GetFileName(Functions.decodeURL(URL));
            sfd.Filter = "Media File (*" + System.IO.Path.GetExtension(URL) + ")|*" + System.IO.Path.GetExtension(URL);
            
            if (sfd.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(sfd.FileName)) {
                try {
                    var Download = new Forms.Download(URL, sfd.FileName);
                    Download.ShowDialog(this);
                } catch (Exception ex) {
                    MessageBox.Show("The media file you are trying to download may be corrupt or may not exist.\n(" + ex.Message + ')', "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(URL)) {
                var process = new Process { StartInfo = {
                    FileName = "explorer.exe",
                    Arguments = "/select,\"" + URL + '\"',
                    WindowStyle = ProcessWindowStyle.Normal }
                };
                process.Start();
            } else {
                MessageBox.Show("Possible Reasons:\n1. File is located on the internet.\n2. The file may have been moved or deleted.", "Error Opening Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void playNextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playFile(true);
        }

        private void playPreviousFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playFile(false);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region View
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showFullScreenDialog) {
                if (MessageBox.Show("To exit Full Screen mode, press Alt+Enter.", "To Exit Full Screen", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    showFullScreenDialog = false;
                    WMP.fullScreen = true;
                }
            } else
                WMP.fullScreen = true;
        }

        private void fitToVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vidWidth = WMP.currentMedia.imageSourceWidth;
            int vidHeight = WMP.currentMedia.imageSourceHeight;
            if (isMusicFile == false) {
                if (mainSplitContainer.Panel2Collapsed == false) {
                    // ~ playlist open ~
                    // set width
                    this.Width = Convert.ToInt32((double)WMP.Height * vidWidth / vidHeight) + (this.Width - mainSplitContainer.SplitterDistance);
                    // set height
                    int newHeight = Convert.ToInt32((double)WMP.Width * vidHeight / vidWidth);
                    this.Height = newHeight + (mainMenuStripX.Height + seekPanel.Height + controlPanel.Height + SystemInformation.VerticalResizeBorderThickness * 2 + SystemInformation.CaptionHeight);
                } else {
                    // ~ playlist closed ~
                    // set width
                    this.Width = Convert.ToInt32((double)WMP.Height * vidWidth / vidHeight);
                    // set height
                    this.Height = Convert.ToInt32((double)WMP.Width * vidHeight / vidWidth) +
                        (mainMenuStripX.Height + seekPanel.Height + controlPanel.Height + SystemInformation.VerticalResizeBorderThickness * 2 + SystemInformation.CaptionHeight);
                }
            } else {
                this.Size = this.MinimumSize;
            }
        }
        #endregion
        #region Playback
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                WMP.Ctlcontrols.pause();
            else
                WMP.Ctlcontrols.play();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }

        private void rewindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.currentPosition = 0;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.currentPosition = 0;
            WMP.Ctlcontrols.play();
        }

        private void increaseVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WMP.settings.volume > 95 & WMP.settings.volume < 100)
                updateVolume(100);
            else if (WMP.settings.volume <= 95 | WMP.settings.volume == 100)
                updateVolume(WMP.settings.volume + 5);
        }

        private void decreaseVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WMP.settings.volume < 5 & WMP.settings.volume > 0)
                updateVolume(0);
            else if (WMP.settings.volume >= 5 | WMP.settings.volume == 0)
                updateVolume(WMP.settings.volume - 5);
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shuffleToolStripMenuItem.Checked) {
                shufflePlaylist();
            } else {
                changePlaylist = true;
                startPlaylist();
            }
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            offToolStripMenuItem.Checked = true;
            allToolStripMenuItem.Checked = false;
            thisToolStripMenuItem.Checked = false;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allToolStripMenuItem.Checked = true;
            offToolStripMenuItem.Checked = false;
            thisToolStripMenuItem.Checked = false;
        }

        private void thisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisToolStripMenuItem.Checked = true;
            offToolStripMenuItem.Checked = false;
            allToolStripMenuItem.Checked = false;
        }

        private void jumpToTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set JumpTo
            JumpTo.currentSec = WMP.Ctlcontrols.currentPosition;
            JumpTo.totalSec = WMP.currentMedia.duration;
            if (JumpTo.ShowDialog(this) == DialogResult.OK)
                WMP.Ctlcontrols.currentPosition = JumpTo.newTime;
        }
        #endregion
        #region DVD
        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.dvd.back();
        }

        private void rootMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.dvd.topMenu();
        }

        private void titleMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.dvd.titleMenu();
        }
        #endregion
        #region Tools
        private void takeSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Graphics.CopyFromScreen Method (Int32, Int32, Int32, Int32, Size)
            //var snapshotDialog = new SaveFileDialog {
            //    Title = "Save Snapshot", Filter = "MP3 File|*.*"};
            //if (snapshotDialog.ShowDialog(this) != DialogResult.OK) return;
            //// begin snapshot
            //Bitmap snapshot;
            //Graphics myGraphics = this.CreateGraphics();
            //Size s = this.Size;
            //snapshot = new Bitmap(s.Width, s.Height, myGraphics);
            //Graphics memory = Graphics.FromImage(snapshot);
            //memory.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            Bitmap bmpSnapshot;
            Graphics gfxScreenshot;
            
            // If the user has choosed a path where to save the screenshot
            if (SaveSnapshot.ShowDialog() == DialogResult.OK) {
                // Hide the form so that it does not appear in the screenshot
                this.Hide();
                // Set the bitmap object to the size of the screen
                bmpSnapshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                // Create a graphics object from the bitmap
                gfxScreenshot = Graphics.FromImage(bmpSnapshot);
                // Take the screenshot from the upper left corner to the right bottom corner
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                // Save the screenshot to the specified path that the user has chosen
                //bmpSnapshot.Save(SFD.FileName, ImageFormat.Png);
                // Show the form again
                this.Show();
            }

            /*
             // Save the image as BMP, JPG, PNG, GIF
    bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif)
             * 
        If System.IO.File.Exists(WMP.URL) = True Then
            'File is in Hard Drive
            OFD.InitialDirectory = System.IO.Path.GetDirectoryName(WMP.URL)
            OFD.FileName = System.IO.Path.GetFileName(WMP.URL)
        End If
             */
        }

     
        private void mediaInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set info
            MediaInfo.URL = URL;
            MediaInfo.width = WMP.currentMedia.imageSourceWidth;
            MediaInfo.height = WMP.currentMedia.imageSourceHeight;
            MediaInfo.ShowDialog(this);
        }
        #endregion
        #region Options
        private void showPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showPlaylistToolStripMenuItem.Checked)
                togglePlaylist(1);
            else
                togglePlaylist(0);
        }

        private void hideAlbumArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideAlbumArtToolStripMenuItem.Checked) {
                mainSplitContainer.Panel1Collapsed = true;
                showPlaylistToolStripMenuItem.Checked = true;
                showPlaylistToolStripMenuItem_Click(null, null);
            } else {
                mainSplitContainer.Panel1Collapsed = false;
            }
        }

        public bool SetFocus {
            set { this.Focus(); }
        }

        private void dimLightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dimLightsToolStripMenuItem.Checked) {
                this.Owner = Black;
                Black.Show();
            } else
                Black.Visible = false;
        }

        private void alwaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alwaysToolStripMenuItem.Checked = true;
            whenPlayingToolStripMenuItem.Checked = false;
            neverToolStripMenuItem.Checked = false;
            setOnTop();
        }

        private void whenPlayingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whenPlayingToolStripMenuItem.Checked = true;
            alwaysToolStripMenuItem.Checked = false;
            neverToolStripMenuItem.Checked = false;
            setOnTop();
        }

        private void neverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neverToolStripMenuItem.Checked = true;
            alwaysToolStripMenuItem.Checked = false;
            whenPlayingToolStripMenuItem.Checked = false;
            setOnTop();
        }

        private void setOnTop() {
            if (whenPlayingToolStripMenuItem.Checked)
                this.TopMost = (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying);
            else if (alwaysToolStripMenuItem.Checked)
                this.TopMost = true;
            else if (neverToolStripMenuItem.Checked)
                this.TopMost = false;
        }

        private void showIconInTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showIconInTrayToolStripMenuItem.Checked) {
                minimizeToSystemTrayToolStripMenuItem.Enabled = true;
                Properties.Settings.Default.ShowIcon = true;
                mainNotifyIcon.Visible = true;
            } else {
                minimizeToSystemTrayToolStripMenuItem.Enabled = false;
                Properties.Settings.Default.ShowIcon = false;
                mainNotifyIcon.Visible = false;
            }
        }

        private void minimizeToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinimizeToTray = (minimizeToSystemTrayToolStripMenuItem.Checked);
        }
        #endregion
        #region About
        private void getAdditionalCodecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CCCP (codec pack) is outdated
            if (IntPtr.Size == 8) // 64-bit system
                System.Diagnostics.Process.Start("http://www.codecguide.com/klcp_64bit.htm");
            else //if (IntPtr.Size == 4) // 32-bit system
                System.Diagnostics.Process.Start("http://www.codecguide.com/download_k-lite_codec_pack_basic.htm");
        }

        private void aboutAniPlayerXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About.ShowDialog(this);
        }
        #endregion

        #region ~ setMenuStrips & loadSettings ~
        private void setMenuStrips(bool enable) {
            if (enable) {
                fullScreenToolStripMenuItem.Enabled = true;
                fitToVideoToolStripMenuItem.Enabled = true;
                // playback menu
                playToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                rewindToolStripMenuItem.Enabled = true;
                restartToolStripMenuItem.Enabled = true;
                jumpToTimeToolStripMenuItem.Enabled = true;
                // tools menu
                mediaInformationToolStripMenuItem.Enabled = true;
                // options menu
                showPlaylistToolStripMenuItem.Enabled = true;
                // notification area
                playToolStripMenuItem1.Enabled = true;
                stopToolStripMenuItem1.Enabled = true;
                rewindToolStripMenuItem1.Enabled = true;
            } else {
                fullScreenToolStripMenuItem.Enabled = false;
                fitToVideoToolStripMenuItem.Enabled = false;
                // playback menu
                playToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                rewindToolStripMenuItem.Enabled = false;
                restartToolStripMenuItem.Enabled = false;
                jumpToTimeToolStripMenuItem.Enabled = false;
                // tools menu
           
                mediaInformationToolStripMenuItem.Enabled = false;
                // options menu
                showPlaylistToolStripMenuItem.Enabled = false;
                // notification area
                playToolStripMenuItem1.Enabled = false;
                stopToolStripMenuItem1.Enabled = false;
                rewindToolStripMenuItem1.Enabled = false;
            }
        }

        private void loadSettings() {
            // volume
            if (Properties.Settings.Default.Volume != 50)
                updateVolume(Properties.Settings.Default.Volume);
            // icon in system tray
            if (Properties.Settings.Default.ShowIcon == false) {
                mainNotifyIcon.Visible = false;
                showIconInTrayToolStripMenuItem.Enabled = false;
            }
            // minimize to notification area
            if (Properties.Settings.Default.MinimizeToTray) {
                minimizeToSystemTrayToolStripMenuItem.Enabled = true;
                minimizeToSystemTrayToolStripMenuItem.Checked = true;
            }
            // last file
            if (System.IO.File.Exists(Properties.Settings.Default.LastFile)) {
                openLastFileToolStripMenuItem.ToolTipText = System.IO.Path.GetFileName(Properties.Settings.Default.LastFile);
                openLastFileToolStripMenuItem.Enabled = true;
            }
        }
        #endregion

        private void mainForm_Load(object sender, EventArgs e) {
            // check for command line args
            string[] commandLine = Environment.GetCommandLineArgs();
            if (commandLine.Length > 1 && System.IO.File.Exists(commandLine[1]))
                WMP.URL = commandLine[1];
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save settings
            Properties.Settings.Default.Save();
            WMP.close();
        }

        private void Handeled_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    if (seekMouseDown) {
                        // stop mouse movement
                        seekMouseDown = false;
                    } else {
                        // boss mode
                        WMP.Ctlcontrols.pause();
                        Black.Visible = false;
                        this.Opacity = 0.0;
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Minimized;
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.Opacity = 1.0;
                    }
                    break;
                case Keys.Space: // play / pause
                    if (searchBox.Focused == false) {
                        if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                            WMP.Ctlcontrols.pause();
                        else if (WMP.playState == WMPLib.WMPPlayState.wmppsPaused | WMP.playState == WMPLib.WMPPlayState.wmppsStopped)
                            WMP.Ctlcontrols.play();
                    }
                    break;
                case Keys.MediaPlayPause: // media play / pause button
                    e.SuppressKeyPress = true;
                    if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                        WMP.Ctlcontrols.pause();
                    else if (WMP.playState == WMPLib.WMPPlayState.wmppsPaused | WMP.playState == WMPLib.WMPPlayState.wmppsStopped)
                        WMP.Ctlcontrols.play();
                    break;
                case Keys.MediaStop: // media stop button
                    e.SuppressKeyPress = true;
                    WMP.Ctlcontrols.stop();
                    break;
                case Keys.MediaNextTrack: // media next button
                    e.SuppressKeyPress = true;
                    playFile(true);
                    break;
                case Keys.MediaPreviousTrack: // media previous button
                    e.SuppressKeyPress = true;
                    playFile(false);
                    break; 
                case Keys.Enter: // full screen
                    fullScreenToolStripMenuItem.PerformClick();
                    break;
                case Keys.VolumeUp: // volume up button
                    e.SuppressKeyPress = true;
                    if (WMP.settings.volume > 95 & WMP.settings.volume < 100)
                        updateVolume(100);
                    else if (WMP.settings.volume <= 95 | WMP.settings.volume == 100)
                        updateVolume(WMP.settings.volume + 5);
                    break;
                case Keys.VolumeDown: // volume down button
                    e.SuppressKeyPress = true;
                    if (WMP.settings.volume < 5 & WMP.settings.volume > 0)
                        updateVolume(0);
                    else if (WMP.settings.volume >= 5 | WMP.settings.volume == 0)
                        updateVolume(WMP.settings.volume - 5);
                    break;
            }
        }

        private void openFile() {
            ofd.Filter = "All Media Files (Media Files)|*.3gp; *.aac; *.avi; *.flv; *.mid; *.mkv; *.mov; *.mp3; *.mp4; *.mpeg; *.mpg; *.ogg; *.wav; *.wma; *.wmv; *.xvid|All Files (*.*)|*.*";

            if (System.IO.File.Exists(URL)) {
                ofd.InitialDirectory = System.IO.Path.GetDirectoryName(URL);
                ofd.FileName = System.IO.Path.GetFileName(URL);
            } else
                ofd.FileName = string.Empty;

            if (ofd.ShowDialog() == DialogResult.OK & ofd.FileName != String.Empty) {
                try {
                    changePlaylist = true;
                    WMP.URL = ofd.FileName;
                    WMP.Ctlcontrols.play();
                } catch (Exception ex) {
                    WMP.Ctlcontrols.stop();
                    durationTimer.Enabled = false;
                    MessageBox.Show("An unexpected error occured while trying to open the video. Please make sure that the media you have selected is supported by your system.\n(Advanced Info: " + ex.Message + ')', "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void musicPicBox_SizeChanged(object sender, EventArgs e)
        {
           if (musicPicBox.Visible)
            { // music file
                if (hasAlbumPicture) {
                    if (musicPicBox.Width < musicPicBox.Image.Width | musicPicBox.Height < musicPicBox.Image.Height)
                        musicPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                    else
                        musicPicBox.SizeMode = PictureBoxSizeMode.CenterImage;
                } else {
                    if (musicPicBox.Width <= 48 | musicPicBox.Height <= 48) {
                        musicPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                        musicPicBox.Image = Properties.Resources.Music_48;
                    } else if (musicPicBox.Width < 128 | musicPicBox.Height < 128) {
                        musicPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                        musicPicBox.Image = Properties.Resources.Music_128;
                    } else {
                        musicPicBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        musicPicBox.Image = Properties.Resources.Music_128;
                    }
                }
            }
        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e) {
            try {
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen) {
                    if (firstFile == false) {
                        Properties.Settings.Default.LastFile = tempURL;
                        Properties.Settings.Default.Save();
                        openLastFileToolStripMenuItem.ToolTipText = System.IO.Path.GetFileName(tempURL);
                        openLastFileToolStripMenuItem.Enabled = true;
                        changePlaylist = !(System.IO.Path.GetDirectoryName(tempURL) == System.IO.Path.GetDirectoryName(URL));
                    } else {
                        firstFile = false;
                        changePlaylist = true;
                    }
                    tempURL = URL;
                    // get available controls
                    controls = (WMPLib.IWMPControls3)WMP.Ctlcontrols;
                    // get IDv3 tag
                    ID3tag.Read(URL);
                    // video or music
                    isMusicFile = (WMP.currentMedia.imageSourceWidth == 0 & WMP.currentMedia.imageSourceHeight == 0);
                    if (isMusicFile == false) {
                        // video file
                        musicPicBox.Visible = false;
                        WMP.Visible = true;
                        hideAlbumArtToolStripMenuItem.Checked = false;
                        hideAlbumArtToolStripMenuItem_Click(null, null);
                        hideAlbumArtToolStripMenuItem.Enabled = false;
                        takeSnapshotToolStripMenuItem.Enabled = true;
                    } else {
                        // music file
                        WMP.Visible = false;
                        musicPicBox.Visible = true;
                        hideAlbumArtToolStripMenuItem.Enabled = true;
                        takeSnapshotToolStripMenuItem.Enabled = false;
                        // show item artwork
                        ID3FrameCollection frames = ID3tag.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture);
                        if (frames.Count > 0) {
                            ID3v23PictureFrame image = (ID3v23PictureFrame)frames[0];
                            musicPicBox.Image = image.Picture;
                            hasAlbumPicture = true;
                        } else {
                            hasAlbumPicture = false;
                        }
                        musicPicBox_SizeChanged(null, null);
                    }
                    // check if media is online
                    if (System.IO.File.Exists(URL)) {
                        saveMediaAsToolStripMenuItem.Enabled = false;
                        showInWindowsExplorerToolStripMenuItem.Enabled = true;
                        folderToolStripMenuItem.Enabled = true;
                    } else {
                        saveMediaAsToolStripMenuItem.Enabled = true;
                        showInWindowsExplorerToolStripMenuItem.Enabled = false;
                        folderToolStripMenuItem.Enabled = false;
                    }
                    // dvd controls & title
                    WMPLib.IWMPDVD dvd = WMP.dvd;
                    if (dvd.get_isAvailable("dvd")) {
                        dVDToolStripMenuItem.Visible = true;
                        if (dvd.get_isAvailable("resume")) WMP.dvd.resume();
                        goBackToolStripMenuItem.Enabled = (dvd.get_isAvailable("back"));
                        rootMenuToolStripMenuItem.Enabled = (dvd.get_isAvailable("topMenu"));
                        titleMenuToolStripMenuItem.Enabled = (dvd.get_isAvailable("titleMenu"));
                        // update titles
                        this.Text = "DVD Disc";
                        Black.titleLabel.Text = "DVD Disc";
                        folderToolStripMenuItem.Text = "Go to DVD Disc folder";
                    } else {
                        dVDToolStripMenuItem.Visible = false;
                        // update titles
                        string fileName = System.IO.Path.GetFileName(URL);
                        this.Text = Functions.decodeURL(fileName);
                        Black.titleLabel.Text = Functions.decodeURL(System.IO.Path.GetFileNameWithoutExtension(URL));
                        folderToolStripMenuItem.Text = (System.IO.File.Exists(URL)) ? Functions.autoEllipsis(35, Functions.getFolderName(URL)) : string.Empty;; 
                    }
                    // call other methods
                    startPlaylist();
                    setSystemTray();
                }
            } catch {//(Exception ex) {
                //Console.WriteLine(ex.Message);
            }
        }

        private void WMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            setOnTop();
            // update status label
            statusLabel.Text = WMP.status;
            if (statusLabel.Height + statusLabel.Location.Y < seekPanel.Location.Y) {
                statusTimer.Enabled = true;
                statusLabel.Visible = true;
            }
            // wmp status
            switch (WMP.playState) {
                case WMPLib.WMPPlayState.wmppsUndefined:
                    if (string.IsNullOrEmpty(URL)) {
                        seekBar.Enabled = false;
                        durationTimer.Enabled = false;
                        rewindButton.Enabled = false;
                        playButton.Enabled = false;
                        setMenuStrips(false);
                    }
                    break;
                case WMPLib.WMPPlayState.wmppsReady:
                    if (string.IsNullOrEmpty(URL) == false & mediaEnded) {
                        WMP.Ctlcontrols.play();
                        mediaEnded = false;
                    }
                    break;
                case WMPLib.WMPPlayState.wmppsPlaying:
                    seekBar.Enabled = true;
                    durationTimer.Enabled = true;
                    rewindButton.Enabled = true;
                    playButton.Enabled = true;
                    playButton.Image = Properties.Resources.NormalPause;

                    playToolStripMenuItem.Text = "&Pause";
                    playToolStripMenuItem1.Text = "&Pause";
                    setMenuStrips(true);
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    playButton.Image = Properties.Resources.NormalPlay;
                    playToolStripMenuItem.Text = "&Play";
                    playToolStripMenuItem1.Text = "&Play";
                    break;
                case WMPLib.WMPPlayState.wmppsStopped:
                    seekBar.Value = 0;
                    playButton.Image = Properties.Resources.NormalPlay;
                    durationLabel.Text = "STOPPED";

                    playToolStripMenuItem.Text = "&Play";
                    playToolStripMenuItem1.Text = "&Play";
                    break;
                case WMPLib.WMPPlayState.wmppsMediaEnded:
                    if (System.IO.File.Exists(URL)) {
                        if (allToolStripMenuItem.Checked) {
                            if (playlistBox.Items.IndexOf(System.IO.Path.GetFileName(URL)) == playlistBox.Items.Count - 1) {
                                // repeat entire playlist
                                mediaEnded = true;
                                playlistBox.SelectedIndex = 0;
                                setCurrentlySelectedItem();                            
                            } else {
                                // next file
                                mediaEnded = true;
                                playFile(true);
                            }
                        } else if (thisToolStripMenuItem.Checked) {
                            // repeat this
                            mediaEnded = true;
                            //WMP.Ctlcontrols.currentPosition = 0;
                            //WMP.Ctlcontrols.play();
                            
                            // TEMPORARY FIX
                            WMP.URL = WMP.currentMedia.sourceURL;
                        } else if (offToolStripMenuItem.Checked) {
                            // repeat off
                            mediaEnded = true;
                            playFile(true);
                        }
                    }
                    break;
            }
        }

        private void WMP_Buffering(object sender, AxWMPLib._WMPOCXEvents_BufferingEvent e)
        {
            if (e.start) {
                // buffering begins
                if (quickButton.Image.PhysicalDimension.Width == 27 & quickButton.Image.PhysicalDimension.Height == 28) {
                    quickButton.Image = Properties.Resources.loader;
                    nowPlayingToolStripMenuItem.Text = "Loading...";
                    //durationTimer.Enabled = true;
                }
            } else {
                // buffering ends
                quickButton.Image = Properties.Resources.QuickButton_Default;
                updateNowPlayingInfo();
            }
        }

        private void mainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) {
                // scroll up
                if (WMP.settings.volume > 95 & WMP.settings.volume < 100)
                    updateVolume(100);
                else if (WMP.settings.volume <= 95 | WMP.settings.volume == 100)
                    updateVolume(WMP.settings.volume + 5);
            } else {
                // scroll down
                if (WMP.settings.volume < 5 & WMP.settings.volume > 0)
                    updateVolume(0);
                else if (WMP.settings.volume >= 5 | WMP.settings.volume == 0)
                    updateVolume(WMP.settings.volume - 5);
            }
        }

        #region StatusLabel Stuff
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (WMP.playState != WMPLib.WMPPlayState.wmppsBuffering |
               WMP.playState != WMPLib.WMPPlayState.wmppsReconnecting) {
                statusLabel.Visible = false;
                statusTimer.Enabled = false;
            }
        }

        private void statusLabel_MouseClick(object sender, MouseEventArgs e)
        {
            statusTimer.Enabled = false;
            statusLabel.Visible = false;
        }
        #endregion
        #region Quick Button
        private void quickButton_MouseDown(object sender, MouseEventArgs e)
        {
            quickButton.Image = Properties.Resources.QuickButton_MouseDown;
        }

        private void quickButton_MouseUp(object sender, MouseEventArgs e)
        {
            quickButton.Image = Properties.Resources.QuickButton_Default;
        }

        private void quickButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch(e.Button) {
                case MouseButtons.Left:
                    openFile();
                    break;
                case MouseButtons.Middle:
                    if (string.IsNullOrEmpty(URL) == false) {
                        // set JumpTo
                        JumpTo.currentSec = WMP.Ctlcontrols.currentPosition;
                        JumpTo.totalSec = WMP.currentMedia.duration;
                        if (JumpTo.ShowDialog(this) == DialogResult.OK)
                            WMP.Ctlcontrols.currentPosition = JumpTo.newTime;
                    }
                    break;
                case MouseButtons.Right:
                    Web.URL = URL;
                    if (Web.ShowDialog(this) == DialogResult.OK) {
                        changePlaylist = true;
                        WMP.URL = Web.urlTextBox.Text;
                    }
                    break;
            }
        }
        #endregion
        #region Control Panel Playback Controls
        // ~ Enabled Changed ~
        private void timeLeftLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(URL) == false) {
                if (Properties.Settings.Default.TimeRemaining == true) {
                    // display time remaining
                    Properties.Settings.Default.TimeRemaining = false;
                    double time = WMP.currentMedia.duration - WMP.Ctlcontrols.currentPosition;
                    int hour = (int)(time / 3600);
                    int min = (int)((time % 3600) / 60);
                    int sec = (int)(time % 60);
                    if (hour > 0)
                        timeLeftLabel.Text = '-' + hour.ToString("#0") + ':' + min.ToString("#0") + ':' + sec.ToString("00");
                    else
                        timeLeftLabel.Text = '-' + min.ToString("#0") + ':' + sec.ToString("00");
                } else {
                    // display total media time
                    Properties.Settings.Default.TimeRemaining = true;
                    timeLeftLabel.Text = Functions.removeZero(WMP.currentMedia.durationString);
                }
            }
        }

        private void rewindButton_EnabledChanged(object sender, EventArgs e)
        {
            if (rewindButton.Enabled)
                rewindButton.Image = Properties.Resources.NormalReverse;
            else
                rewindButton.Image = Properties.Resources.DisabledReverse;
        }

        private void previousButton_EnabledChanged(object sender, EventArgs e)
        {
            if (previousButton.Enabled)
                previousButton.Image = Properties.Resources.NormalPrevious;
            else
                previousButton.Image = Properties.Resources.DisabledPrevious;
        }

        private void nextButton_EnabledChanged(object sender, EventArgs e)
        {
            if (nextButton.Enabled)
                nextButton.Image = Properties.Resources.NormalForward;
            else
                nextButton.Image = Properties.Resources.DisabledForward;
        }

        private void playButton_EnabledChanged(object sender, EventArgs e)
        {
            if (playButton.Enabled)
                playButton.Image = Properties.Resources.NormalPlay;
            else
                playButton.Image = Properties.Resources.DisabledPlay;
        }
        // ~ Events ~
        // rewind button
        private void rewindButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    WMP.Ctlcontrols.currentPosition = 0;
                else
                    WMP.Ctlcontrols.stop();
            }
        }

        private void rewindButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (rewindButton.Enabled & e.Button == MouseButtons.Left)
                rewindButton.Image = Properties.Resources.MouseDownReverse;
        }

        private void rewindButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (rewindButton.Enabled)
                rewindButton.Image = Properties.Resources.NormalReverse;
            else
                rewindButton.Image = Properties.Resources.DisabledReverse;
        }
        // previous button
        private void previousButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                playFile(false);
        }

        private void previousButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (previousButton.Enabled & e.Button == MouseButtons.Left)
                previousButton.Image = Properties.Resources.MouseDownPrevious;
        }

        private void previousButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (previousButton.Enabled)
                previousButton.Image = Properties.Resources.NormalPrevious;
            else
                previousButton.Image = Properties.Resources.DisabledReverse;
        }
        // next button
        private void nextButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                playFile(true);
        }

        private void nextButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (nextButton.Enabled & e.Button == MouseButtons.Left)
                nextButton.Image = Properties.Resources.MouseDownForward;
        }

        private void nextButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (nextButton.Enabled)
                nextButton.Image = Properties.Resources.NormalForward;
            else
                nextButton.Image = Properties.Resources.DisabledForward;
        }
        // play button
        private void playButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & playButton.Enabled) {
                if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    playButton.Image = Properties.Resources.MouseDownPause;
                else
                    playButton.Image = Properties.Resources.MouseDownPlay;
            }
        }

        private void playButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & playButton.Enabled) {
                if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                    WMP.Ctlcontrols.pause();
                    playButton.Image = Properties.Resources.NormalPlay;
                } else {
                    //durationTimer.Enabled = true;
                    WMP.Ctlcontrols.play();
                    playButton.Image = Properties.Resources.NormalPause;
                }
            }
        }
        #endregion

        private void mainForm_Resize(object sender, EventArgs e)
        { // status label
            if (statusLabel.Height + statusLabel.Location.Y < seekPanel.Location.Y) {
                // does not overlap
                statusTimer.Enabled = true;
            } else {
                // overlaps
                statusLabel.Visible = false;
                statusTimer.Enabled = false;
            }

            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(URL)) {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "explorer.exe";
                process.StartInfo.Arguments = "/select,\"" + URL + '\"';
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            } else {
                MessageBox.Show("Possible Reasons:\n1. File is located on the internet.\n2. The file may have been moved or deleted.", "Error Opening Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void previousButton_Paint(object sender, PaintEventArgs e)
        {
            if (previousButton.Enabled) {
                Font drawFont = new Font("Segoe UI", 10f);
                SizeF stringSize = new SizeF(e.Graphics.MeasureString((playlistIndex).ToString(), drawFont));
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                float x = ((previousButton.Width - stringSize.Width) / 2) + 4;
                float y = (previousButton.Height - stringSize.Height) / 2;
                e.Graphics.DrawString((playlistIndex).ToString(), drawFont, drawBrush, x, y);
            }
        }

        private void nextButton_Paint(object sender, PaintEventArgs e)
        {
            if (nextButton.Enabled) {
                Font drawFont = new Font("Segoe UI", 10f);
                SizeF stringSize = new SizeF(e.Graphics.MeasureString((playlistIndex + 2).ToString(), drawFont));
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                float x = ((nextButton.Width - stringSize.Width) / 2) - 4;
                float y = (nextButton.Height - stringSize.Height) / 2;
                e.Graphics.DrawString((playlistIndex + 2).ToString(), drawFont, drawBrush, x, y);
            }
        }

        private void durationTimer_Tick(object sender, EventArgs e)
        {
            updateNowPlayingInfo();
            if (seekMouseDown == false) {
                double currentPos = WMP.Ctlcontrols.currentPosition * 1000;
                double durationVar = WMP.currentMedia.duration * 1000;
                if (durationVar > 0)
                    seekBar.Value = Convert.ToInt32((currentPos * 1000) / durationVar); // % complete
                // update the time label
                if (WMP.playState == WMPLib.WMPPlayState.wmppsStopped)
                    durationLabel.Text = "STOPPED";
                else
                    durationLabel.Text = Functions.removeZero(WMP.Ctlcontrols.currentPositionString);
                if (Properties.Settings.Default.TimeRemaining) {
                    // calculate time remaining & displays it
                    timeLeftLabel.Text = '-' + Functions.removeZero(Functions.convertTime(WMP.currentMedia.duration - WMP.Ctlcontrols.currentPosition));
                } else {
                    // display total media duration time
                    timeLeftLabel.Text = Functions.removeZero(WMP.currentMedia.durationString);
                }
                // update MediaInfo
                if (MediaInfo.Visible)
                    MediaInfo.durationTextBox.Text = durationLabel.Text + " / " + Functions.removeZero(WMP.currentMedia.durationString) + " (" + ((double)seekBar.Value / seekBar.Maximum * 100).ToString("###.0") + "%)";
            }
        }

        #region seekBar events
        private void seekBar_MouseDown(object sender, MouseEventArgs e)
        {
            seekMouseDown = true;
        }

        private void seekBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (seekMouseDown == true) {
                double currentPos = seekBar.Value * WMP.currentMedia.duration / seekBar.Maximum;
                if (Properties.Settings.Default.TimeRemaining == true) {
                    timeLeftLabel.Text = '-' + Functions.removeZero(Functions.convertTime(WMP.currentMedia.duration - currentPos));
                } else {
                    timeLeftLabel.Text = Functions.removeZero(currentPos.ToString());
                }
                durationLabel.Text = Functions.removeZero(Functions.convertTime(currentPos));
            }
        }

        private void seekBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (seekMouseDown) {
                WMP.Ctlcontrols.currentPosition = WMP.currentMedia.duration * ((double)seekBar.Value / seekBar.Maximum);
                seekMouseDown = false;
            }
        }
        #endregion

        #region Playlist Drag & Drop (w/ Delete) Code
        // declarations
        Cursor playlistCur;
        int index = -1;

        public void drawCursor(string text)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            SizeF sz = g.MeasureString(text, playlistBox.Font);
            bmp = new Bitmap(Convert.ToInt32(sz.Width), Convert.ToInt32(sz.Height));
            g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(255, 30, 30, 30));
            g.DrawString(text, playlistBox.Font, Brushes.White, 0, 0);
            g.DrawRectangle(Pens.Gray, new Rectangle(0, 0, bmp.Width - 1, bmp.Height - 1));
            g.Dispose();
            playlistCur = new Cursor(bmp.GetHicon());
            bmp.Dispose();
        }

        private void playlistBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete & playlistBox.SelectedIndex != playlistIndex & playlistBox.SelectedIndex != -1) {
                int index = playlistBox.SelectedIndex;
                if (askDelete) {
                    if (MessageBox.Show("Remove \"" + playlistBox.SelectedItem.ToString() + "\" from playlist?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                        playlistBox.Items.RemoveAt(index);
                        askDelete = false;
                        if (index == 0)
                            playlistBox.SelectedIndex = 0;
                        else if (index == playlistBox.Items.Count)
                            playlistBox.SelectedIndex = playlistBox.Items.Count - 1;
                        else
                            playlistBox.SelectedIndex = index;
                    }
                } else {
                    playlistBox.Items.RemoveAt(index);
                    if (index == 0)
                        playlistBox.SelectedIndex = 0;
                    else if (index == playlistBox.Items.Count)
                        playlistBox.SelectedIndex = playlistBox.Items.Count - 1;
                    else
                        playlistBox.SelectedIndex = index;
                }
            playlistIndex = playlistBox.FindString(System.IO.Path.GetFileName(URL));
            }
        }

        private void playlistBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) {
                int ix = playlistBox.IndexFromPoint(playlistBox.PointToClient(new Point(e.X, e.Y)));
                if (ix == -1) ix = playlistBox.Items.Count;
                playlistBox.Items.Insert(ix, e.Data.GetData(DataFormats.Text));
                playlistBox.SelectedIndex = ix;
                if (index != -1 & index >= ix)
                    index += 1;
                if (index != -1)
                    playlistBox.Items.RemoveAt(index);
                //~index = -1; // ??
                shuffleToolStripMenuItem.Checked = false;
                setControlButtons();
            }
        }

        private void playlistBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.Text) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void playlistBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) {
                drawCursor(playlistBox.Items[index].ToString());
                e.Effect = DragDropEffects.Move;
                playlistBox.SelectedIndex = playlistBox.IndexFromPoint(playlistBox.PointToClient(new Point(e.X, e.Y)));
            }
        }

        private void playlistBox_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move) {
                if (index != -1) {
                    playlistBox.DoDragDrop(playlistBox.Items[index].ToString(), DragDropEffects.Move);
                }
                // change cursor
                e.UseDefaultCursors = false;
                Cursor.Current = playlistCur;
            }
        }

        private void playlistBox_MouseDown(object sender, MouseEventArgs e)
        {
            startDragDrop = true;
        }

        private void playlistBox_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (startDragDrop == true) {
                index = playlistBox.IndexFromPoint(e.Location);
                if (index != -1) {
                    drawCursor(playlistBox.Items[index].ToString());
                    playlistBox.DoDragDrop(playlistBox.Items[index].ToString(), DragDropEffects.Move);
                }
                startDragDrop = false;
            }*/
        }
        #endregion
        #region playlistBox Code
        private void playlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFileLabel.Text = "File " + (playlistBox.SelectedIndex + 1) + " of " + playlistBox.Items.Count;
        }

        private void currentFileLabel_MouseDown(object sender, MouseEventArgs e)
        {
            var inputBox = new Forms.InputBox("Enter the file number you want to play:\nNote: Value must be between 1 - " + playlistBox.Items.Count, "Enter File Number", (playlistBox.FindString(System.IO.Path.GetFileName(URL)) + 1).ToString());
            if (inputBox.ShowDialog(this) == DialogResult.OK) {
                int i; int.TryParse(inputBox.enteredText, out i); --i;
                if (i >= 0 && i < playlistBox.Items.Count) {
                    playlistBox.SelectedIndex = i;
                    WMP.URL = System.IO.Path.GetDirectoryName(URL) + '\\' + playlistBox.SelectedItem.ToString();
                }
            }
        }

        private void playlistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startDragDrop = false;
            setCurrentlySelectedItem();
        }

        private void setCurrentlySelectedItem() {
            string directory = System.IO.Path.GetDirectoryName(URL) + '\\' + playlistBox.SelectedItem.ToString();
            if (playlistBox.SelectedIndex > -1 & directory != URL) {
                if (System.IO.File.Exists(directory))
                    WMP.URL = directory;
            }
        }

        private void startPlaylist() {
            // begin update
            playlistBox.BeginUpdate();
            if (System.IO.File.Exists(URL)) {
                // set pattern & path
                if (changePlaylist) setPlaylist(System.IO.Path.GetDirectoryName(URL));
                // select current file
                playlistBox.SelectedIndex = playlistBox.Items.IndexOf(System.IO.Path.GetFileName(URL));
                // allow playlist usage
                selectCurrentFileToolStripMenuItem.Enabled = true;
                showAllFilesToolStripMenuItem.Enabled = true;
                refreshPlaylistToolStripMenuItem.Enabled = true;
                showPlaylistToolStripMenuItem.Enabled = true;
                playlistButton.Enabled = true;
                if (playlistBox.Items.Count > 1)
                    togglePlaylist(1);
                else
                    togglePlaylist(0);
            } else {
                // disable playlist usage
                selectCurrentFileToolStripMenuItem.Enabled = false;
                showAllFilesToolStripMenuItem.Enabled = false;
                refreshPlaylistToolStripMenuItem.Enabled = false;
                showPlaylistToolStripMenuItem.Enabled = false;
                playlistButton.Enabled = false;
                togglePlaylist(0);
                playlistBox.Items.Clear();
            }
            if (changePlaylist) shuffleToolStripMenuItem.Checked = false;
            // redraws playlist
            playlistBox.EndUpdate();
            // get playlist index
            playlistIndex = playlistBox.FindStringExact(System.IO.Path.GetFileName(URL));
            // enable/disable control buttons
            setControlButtons();
        }

        private void setPlaylist(string path) {
            playlistBox.Items.Clear();
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] myFiles;
            if (showAllFilesToolStripMenuItem.Checked)
                myFiles = dirInfo.GetFiles("*.*");
            else
                myFiles = dirInfo.GetFiles('*' + System.IO.Path.GetExtension(URL));
            for (int i = 0; i <= myFiles.Length - 1; i++) {
                if (myFiles[i].Name.EndsWith(".db") == false)
                    playlistBox.Items.Add(myFiles[i].Name);
            }
        }

        private void setControlButtons() {
            bool firstVid = false; bool lastVid = false;
            if (playlistBox.Items.Count > 1) {
                if (playlistIndex == 0)
                    firstVid = true;
                else if (playlistIndex + 1 == playlistBox.Items.Count)
                    lastVid = true;
            } else {
                previousButton.Enabled = false;
                nextButton.Enabled = false;
                previousButton.Refresh();
                nextButton.Refresh();
                playPreviousFileToolStripMenuItem.Enabled = false;
                playNextFileToolStripMenuItem.Enabled = false;
                // notification area
                previousToolStripMenuItem.Enabled = false;
                nextToolStripMenuItem.Enabled = false;
                return;
            }

            if (firstVid) {
                previousButton.Enabled = false;
                nextButton.Enabled = true;
                playPreviousFileToolStripMenuItem.Enabled = false;
                playNextFileToolStripMenuItem.Enabled = true;
                // notification area
                previousToolStripMenuItem.Enabled = false;
                nextToolStripMenuItem.Enabled = true;
            } else if (lastVid == true) {
                previousButton.Enabled = true;
                nextButton.Enabled = false;
                playPreviousFileToolStripMenuItem.Enabled = true;
                playNextFileToolStripMenuItem.Enabled = false;
                // notification area
                previousToolStripMenuItem.Enabled = true;
                nextToolStripMenuItem.Enabled = false;
            } else {
                previousButton.Enabled = true;
                nextButton.Enabled = true;
                playPreviousFileToolStripMenuItem.Enabled = true;
                playNextFileToolStripMenuItem.Enabled = true;
                // notification area
                previousToolStripMenuItem.Enabled = true;
                nextToolStripMenuItem.Enabled = true;
            }
            previousButton.Refresh();
            nextButton.Refresh();
        }
        #endregion
        #region searchBox Code
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (playlistBox.Items.Count > 1) {
                if (searchBox.TextLength > 0) {
                    int itemIndex = playlistBox.FindString(searchBox.Text);
                    if (itemIndex != -1)
                        playlistBox.SelectedIndex = itemIndex;
                } else {
                    playlistBox.SelectedIndex = playlistIndex;
                }
            }
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & playlistBox.Items.Count > 1) {
                string dirString = System.IO.Path.GetDirectoryName(URL) + '\\' + playlistBox.SelectedItem.ToString();
                if (playlistBox.SelectedIndex != -1 & dirString != URL) {
                    if (System.IO.File.Exists(dirString) == true) {
                        WMP.URL = dirString;
                        searchBox.Text = string.Empty;
                    } else {
                        MessageBox.Show(playlistBox.SelectedItem.ToString() + " does not exist in this folder!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        searchBox.Focus();
                    }
                }
            }
        }
        #endregion
        #region playlistButton
        private void playlistButton_EnabledChanged(object sender, EventArgs e)
        {
            if (playlistButton.Enabled)
                playlistButton.Image = Properties.Resources.NormalPlaylist;
            else
                playlistButton.Image = Properties.Resources.DisabledPlaylist;
        }

        private void playlistButton_MouseDown(object sender, MouseEventArgs e)
        {
            playlistButton.Image = Properties.Resources.MouseDownPlaylist;
        }

        private void playlistButton_MouseUp(object sender, MouseEventArgs e)
        {
            playlistButton.Image = Properties.Resources.NormalPlaylist;
        }

        private void playlistButton_MouseClick(object sender, MouseEventArgs e)
        {
            togglePlaylist(2);

            if (mainSplitContainer.Panel2Collapsed)
                showPlaylistToolStripMenuItem.Checked = false;
            else
                showPlaylistToolStripMenuItem.Checked = true;

            hideAlbumArtToolStripMenuItem.Checked = false;
        }
        #endregion
        #region searchBox Options
        private void selectCurrentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playlistBox.SelectedIndex = playlistIndex;
        }

        private void showAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePlaylist = true;
            startPlaylist();
        }

        private void refreshPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePlaylist = true;
            startPlaylist();
        }
        #endregion

        private void playFile(bool nextFile) {
            if (nextFile) {
                // play next file
                if (playlistIndex + 1 < playlistBox.Items.Count) {
                    playlistBox.SelectedIndex = playlistIndex + 1;
                    WMP.URL = System.IO.Path.GetDirectoryName(URL) + '\\' + playlistBox.SelectedItem.ToString();
                    WMP.Ctlcontrols.play();
                } else {
                    WMP.Ctlcontrols.stop();
                    System.Media.SystemSounds.Beep.Play();
                }
            } else {
                // play previous file
                if (playlistIndex - 1 >= 0) {
                    playlistBox.SelectedIndex = playlistIndex - 1;
                    WMP.URL = System.IO.Path.GetDirectoryName(URL) + '\\' + playlistBox.SelectedItem.ToString();
                    WMP.Ctlcontrols.play();
                } else {
                    WMP.Ctlcontrols.pause();
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void toggleToTaskbar(bool minimize) {       
            if (minimize) {
                // minimize to notification area
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            } else {
                // restore form
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;                
            }
        }

        private void setSystemTray() {
            string title = Functions.autoEllipsis(25, ID3tag.Title.Trim());
            string artist = Functions.autoEllipsis(25, ID3tag.Artist.Trim());
            int filePos = playlistBox.Items.IndexOf(System.IO.Path.GetFileName(URL)) + 1; const string shiftSpace = "  ";
            if (string.IsNullOrEmpty(title) == false) {
                if (string.IsNullOrEmpty(artist) == false) {
                    // both available
                    titleToolStripMenuItem.Text = shiftSpace + title;
                    artistToolStripMenuItem.Text = shiftSpace + artist;
                    string lastPart = artist + "\n(File " + filePos + " of " + playlistBox.Items.Count + ')';
                    mainNotifyIcon.Text = title + '\n' + lastPart;
                    if (isMusicFile) mainNotifyIcon.ShowBalloonTip(4000, title, lastPart, ToolTipIcon.None);
                } else {
                    // no artist
                    titleToolStripMenuItem.Text = shiftSpace + title;
                    artistToolStripMenuItem.Text = shiftSpace + "Unknown Artist";
                    string lastPart = "(File " + filePos + " of " + playlistBox.Items.Count + ')';
                    mainNotifyIcon.Text = title + '\n' + lastPart;
                    if (isMusicFile) mainNotifyIcon.ShowBalloonTip(4000, title, lastPart, ToolTipIcon.None);
                }
            } else {
                // no title & artist (no artist assumed)
                string fullFileName = System.IO.Path.GetFileNameWithoutExtension(URL);
                titleToolStripMenuItem.Text = shiftSpace + Functions.autoEllipsis(25, fullFileName);
                artistToolStripMenuItem.Text = shiftSpace + "Unknown Artist";
                string lastPart = "(File " + filePos + " of " + playlistBox.Items.Count + ')';
                mainNotifyIcon.Text = Functions.autoEllipsis(25, fullFileName) + '\n' + lastPart;
                if (isMusicFile) mainNotifyIcon.ShowBalloonTip(4000, fullFileName, lastPart, ToolTipIcon.None);
            }
        }

        private void shufflePlaylist() {
            var randomGen = new Random();
            int index1, index2;
            int maxVal = playlistBox.Items.Count;
            string temp = string.Empty;

            playlistBox.BeginUpdate();
            // make current file's index 0
            playlistBox.Items.Remove(System.IO.Path.GetFileName(URL));
            playlistBox.Items.Insert(0, System.IO.Path.GetFileName(URL));

            for (int i = 1; i <= maxVal - 1; i++) {
                // generate two random numbers
                index1 = randomGen.Next(1, maxVal);
                index2 = randomGen.Next(1, maxVal);
                // swap the two items
                temp = playlistBox.Items[index1].ToString();
                playlistBox.Items[index1] = playlistBox.Items[index2];
                playlistBox.Items[index2] = temp;
            }
            playlistBox.EndUpdate();
            changePlaylist = false;
            playlistBox.SelectedIndex = 0;
            playlistIndex = 0;
            setControlButtons();
        }

        private void updateNowPlayingInfo() {
            //nowPlayingToolStripMenuItem
            WMPLib.WMPPlayState currentState = WMP.playState;
            if (currentState == WMPLib.WMPPlayState.wmppsPlaying)
                nowPlayingToolStripMenuItem.Text = "Now Playing (" + Functions.removeZero(WMP.Ctlcontrols.currentPositionString) + ')';
            else if (currentState == WMPLib.WMPPlayState.wmppsPaused)
                nowPlayingToolStripMenuItem.Text = "Paused (" + Functions.removeZero(WMP.Ctlcontrols.currentPositionString) + ')';
            else if (currentState == WMPLib.WMPPlayState.wmppsStopped)
                nowPlayingToolStripMenuItem.Text = "Stopped";
            else
                nowPlayingToolStripMenuItem.Text = "Now Playing (00:00:00)";
        }

        private void updateVolume(int newVol) {
            if (!volumeBar.Enabled) return;
            if (newVol >= 0 & newVol <= 100) {
                WMP.settings.volume = newVol;
                Properties.Settings.Default.Volume = newVol;
                if (newVol == 0) {
                    WMP.settings.mute = true;
                    volumeToolStripTextBox.Text = "Mute";
                    volumeToolStripTextBox1.Text = "Mute";
                    volumeBar.TrackerColor = Color.SteelBlue;
                    volumeBar.Value = 0;
                } else {
                    WMP.settings.mute = false;
                    volumeToolStripTextBox.Text = newVol.ToString();
                    volumeToolStripTextBox1.Text = newVol.ToString();
                    volumeBar.TrackerColor = Color.DodgerBlue;
                    volumeBar.Value = newVol;
                }
            }
        }

        #region VolumeBar
        private void volumeBar_EnabledChanged(object sender, EventArgs e)
        {
            if (volumeBar.Enabled == true)
                volumeBar.TrackerColor = Color.DodgerBlue;
            else
                volumeBar.TrackerColor = Color.Gray;
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            updateVolume(volumeBar.Value);
        }
        #endregion


        #region Notification Icon
        private void showNikoNekoPureyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible == false)
                toggleToTaskbar(false);
            else {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
            }
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                WMP.Ctlcontrols.pause();
            else if (WMP.playState == WMPLib.WMPPlayState.wmppsPaused | WMP.playState == WMPLib.WMPPlayState.wmppsStopped)
                WMP.Ctlcontrols.play();
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }

        private void rewindToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                WMP.Ctlcontrols.currentPosition = 0;
                WMP.Ctlcontrols.play();
            } else {
                WMP.Ctlcontrols.stop();
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playFile(true);
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playFile(false);
        }

        private void volumeToolStripTextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            ToolStripTextBox theSender = (ToolStripTextBox)sender;
            int newVol; int.TryParse(theSender.Text, out newVol);
            switch (e.KeyCode) {
                case Keys.Enter:
                    if (theSender.Text.ToLower() == "mute" | newVol == 0) {
                        updateVolume(0);
                        notifyIconContextMenuStrip.Hide(); optionsToolStripMenuItem.HideDropDown();
                    } else if (newVol > 0 & newVol <= 100) {
                        updateVolume(newVol);
                        notifyIconContextMenuStrip.Hide(); optionsToolStripMenuItem.HideDropDown();
                    } else {
                        MessageBox.Show("Please enter a value that is between 1 - 100.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        updateVolume(WMP.settings.volume);
                    }
                    break;
                case Keys.Up:
                    if (newVol >= 0 & newVol < 100)
                        theSender.Text = (newVol + 1).ToString();
                    break;
                case Keys.Down:
                    if (newVol > 0 & newVol <= 100)
                        theSender.Text = (newVol - 1).ToString();
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // code for icon itself
        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && string.IsNullOrEmpty(URL) == false) {
                if (e.Clicks == 2) { // does not work?
                    if (this.Visible == false) {
                        toggleToTaskbar(false);
                    } else {
                        this.WindowState = FormWindowState.Normal;
                        this.Focus();
                    }
                } else {
                    if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                        WMP.Ctlcontrols.pause();
                        mainNotifyIcon.ShowBalloonTip(4000, "Paused", this.Text, ToolTipIcon.None);
                    } else if (WMP.playState == WMPLib.WMPPlayState.wmppsPaused) {
                        WMP.Ctlcontrols.play();
                        mainNotifyIcon.ShowBalloonTip(4000, "Playing", this.Text, ToolTipIcon.None);
                    } else if (WMP.playState == WMPLib.WMPPlayState.wmppsStopped) {
                        WMP.Ctlcontrols.play();
                        mainNotifyIcon.ShowBalloonTip(4000, "Playing", this.Text, ToolTipIcon.None);
                    }                
                }
            }
        }
        #endregion

        private void togglePlaylist(int option) {
            if (option == 0) {
                // hide playlist
                mainSplitContainer.Panel2Collapsed = true;
                searchBox.Enabled = false;
                showPlaylistToolStripMenuItem.Checked = false;
                hideAlbumArtToolStripMenuItem.Checked = false;
                hideAlbumArtToolStripMenuItem_Click(null, null);
            } else if (option == 1) {
                // show playlist
                mainSplitContainer.Panel2Collapsed = false;
                searchBox.Enabled = true;
                showPlaylistToolStripMenuItem.Checked = true;
            } else {
                // auto toggle
                if (mainSplitContainer.Panel2Collapsed == false) {
                    mainSplitContainer.Panel2Collapsed = true;
                    showPlaylistToolStripMenuItem.Checked = true;                    
                } else {
                    mainSplitContainer.Panel2Collapsed = false;
                    showPlaylistToolStripMenuItem.Checked = false;                    
                }
            }
        }

        private void seekBar_EnabledChanged(object sender, EventArgs e)
        {
            seekBar.TrackerColor = seekBar.Enabled ? Color.DodgerBlue : Color.Gray;
        }

        private void WMP_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            try {// If the Player encounters a corrupt or missing file, 
                //  show the hexadecimal error code and URL.
                WMPLib.IWMPMedia2 errSource = e.pMediaObject as WMPLib.IWMPMedia2;
                ErrorForm.errorItem = errSource.Error; ErrorForm.URL = WMP.currentMedia.sourceURL;
                ErrorForm.ShowDialog(this);
            } catch (InvalidCastException) {
                // In case pMediaObject is not an IWMPMedia item.
                MessageBox.Show("M-Lite Media Player run into an unexpected error!", "Error in " + System.IO.Path.GetFileName(URL), MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WMP.URL = string.Empty;
            }
        }

     
    }
}