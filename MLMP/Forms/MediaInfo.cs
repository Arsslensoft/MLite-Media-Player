using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HundredMilesSoftware.UltraID3Lib;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class MediaInfo : DevComponents.DotNetBar.Metro.MetroForm
    {
        private UltraID3 ID3tag = new UltraID3();
        public string URL;
        public int width, height;

        public MediaInfo()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void MediaInfo_Load(object sender, EventArgs e)
        {
            getID3_Tags();
            getAlbumArt();
            getFileInfo();
            if (ID3tag.ID3v2Tag.ExistsInFile | ID3tag.ID3v1Tag.ExistsInFile)
                mainTabControl.SelectTab("mediaInfoPage");
            else
                mainTabControl.SelectTab("fileInfoPage");
        }

        private void getFileInfo() {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(URL);
            // get file name
            nameLabel.Text = Functions.decodeURL(System.IO.Path.GetFileName(URL));
            FileNameTextBox.Text = Functions.decodeURL(System.IO.Path.GetFileName(URL));
            // file size
            FileSizeTextBox.Text = (System.IO.File.Exists(URL) ? Functions.getFileSize(URL, 2) : "Not Available");
            // source
            sourceTextBox.Text = URL;
            // file type & extension;
            NativeMethods.SHFILEINFO info = new NativeMethods.SHFILEINFO();
            uint dwFileAttributes = NativeMethods.FILE_ATTRIBUTE.FILE_ATTRIBUTE_NORMAL;
            uint uFlags = (uint)(NativeMethods.SHGFI.SHGFI_TYPENAME | NativeMethods.SHGFI.SHGFI_USEFILEATTRIBUTES);
            NativeMethods.SHGetFileInfo(URL, dwFileAttributes, ref info, (uint)Marshal.SizeOf(info), uFlags);
            if (string.IsNullOrEmpty(info.szTypeName) == false)
                FileTypeTextBox.Text = info.szTypeName;
            else
                FileTypeTextBox.Text = System.IO.Path.GetExtension(URL).ToUpper() + " File";
            // creation date
            createdTextBox.Text = fileInfo.CreationTime.ToLongDateString();
            // video size
            VideoSizeTextBox.Text = width + " x " + height;
        }

        private void getAlbumArt() {
            ID3FrameCollection frames = ID3tag.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture);
            if (frames.Count > 0) {
                ID3v23PictureFrame image = (ID3v23PictureFrame)frames[0];
                albumArtPicBox.Image = image.Picture;
                picDemensionLabel.Text = image.Picture.Width + " x " + image.Picture.Height;
            } else {
                // no picture
                picDemensionLabel.Text = string.Empty;
            }
        }

        private void getID3_Tags() {
            try {
                ID3tag.Read(URL);
                musicTitle.Text = ID3tag.Title;
                musicArtist.Text = ID3tag.Artist;
                musicAlbum.Text = ID3tag.Album;
                musicYear.Text = ID3tag.Year.ToString();
                musicTrack.Text = ID3tag.TrackNum.ToString();
                if (ID3tag.TrackNum.HasValue) {
                    if (ID3tag.TrackCount.HasValue)
                        trackCountTextBox.Text = ID3tag.TrackCount.ToString();
                    else
                        trackCountTextBox.Text = "?";
                }
                musicGenre.Text = ID3tag.Genre;
                musicComment.Text = ID3tag.Comments;
            } catch { }
        }

    }

    static class NativeMethods {
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        public static class FILE_ATTRIBUTE {
            public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        }

        public static class SHGFI {
            public const uint SHGFI_TYPENAME = 0x000000400;
            public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        }

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
    }
}
