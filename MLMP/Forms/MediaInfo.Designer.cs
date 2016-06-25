namespace MLITEMEDIAPLAYER.Forms
{
    partial class MediaInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaInfo));
            this.nameLabel = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mediaInfoPage = new System.Windows.Forms.TabPage();
            this.picDemensionLabel = new System.Windows.Forms.Label();
            this.trackCountTextBox = new System.Windows.Forms.TextBox();
            this.slashLabel = new System.Windows.Forms.Label();
            this.musicComment = new System.Windows.Forms.TextBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.musicGenre = new System.Windows.Forms.TextBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.musicTrack = new System.Windows.Forms.TextBox();
            this.TrackLabel = new System.Windows.Forms.Label();
            this.musicYear = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.musicAlbum = new System.Windows.Forms.TextBox();
            this.musicArtist = new System.Windows.Forms.TextBox();
            this.musicTitle = new System.Windows.Forms.TextBox();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.albumArtPicBox = new System.Windows.Forms.PictureBox();
            this.fileInfoPage = new System.Windows.Forms.TabPage();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.createdTextBox = new System.Windows.Forms.TextBox();
            this.createdLabel = new System.Windows.Forms.Label();
            this.VideoSizeTextBox = new System.Windows.Forms.TextBox();
            this.VideoSizeLabel = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileSizeTextBox = new System.Windows.Forms.TextBox();
            this.FileTypeTextBox = new System.Windows.Forms.TextBox();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.durationTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTabControl.SuspendLayout();
            this.mediaInfoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtPicBox)).BeginInit();
            this.fileInfoPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(374, 23);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "M-Lite Media Player";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mediaInfoPage);
            this.mainTabControl.Controls.Add(this.fileInfoPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTabControl.Location = new System.Drawing.Point(0, 23);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(374, 276);
            this.mainTabControl.TabIndex = 0;
            // 
            // mediaInfoPage
            // 
            this.mediaInfoPage.BackColor = System.Drawing.Color.Black;
            this.mediaInfoPage.Controls.Add(this.picDemensionLabel);
            this.mediaInfoPage.Controls.Add(this.trackCountTextBox);
            this.mediaInfoPage.Controls.Add(this.slashLabel);
            this.mediaInfoPage.Controls.Add(this.musicComment);
            this.mediaInfoPage.Controls.Add(this.CommentLabel);
            this.mediaInfoPage.Controls.Add(this.musicGenre);
            this.mediaInfoPage.Controls.Add(this.GenreLabel);
            this.mediaInfoPage.Controls.Add(this.musicTrack);
            this.mediaInfoPage.Controls.Add(this.TrackLabel);
            this.mediaInfoPage.Controls.Add(this.musicYear);
            this.mediaInfoPage.Controls.Add(this.YearLabel);
            this.mediaInfoPage.Controls.Add(this.musicAlbum);
            this.mediaInfoPage.Controls.Add(this.musicArtist);
            this.mediaInfoPage.Controls.Add(this.musicTitle);
            this.mediaInfoPage.Controls.Add(this.AlbumLabel);
            this.mediaInfoPage.Controls.Add(this.ArtistLabel);
            this.mediaInfoPage.Controls.Add(this.TitleLabel);
            this.mediaInfoPage.Controls.Add(this.albumArtPicBox);
            this.mediaInfoPage.Location = new System.Drawing.Point(4, 28);
            this.mediaInfoPage.Name = "mediaInfoPage";
            this.mediaInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.mediaInfoPage.Size = new System.Drawing.Size(366, 244);
            this.mediaInfoPage.TabIndex = 0;
            this.mediaInfoPage.Text = "Media Info";
            this.mediaInfoPage.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPages_Paint);
            // 
            // picDemensionLabel
            // 
            this.picDemensionLabel.BackColor = System.Drawing.Color.Transparent;
            this.picDemensionLabel.ForeColor = System.Drawing.Color.Gray;
            this.picDemensionLabel.Location = new System.Drawing.Point(6, 109);
            this.picDemensionLabel.Name = "picDemensionLabel";
            this.picDemensionLabel.Size = new System.Drawing.Size(102, 19);
            this.picDemensionLabel.TabIndex = 19;
            this.picDemensionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackCountTextBox
            // 
            this.trackCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.trackCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackCountTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackCountTextBox.ForeColor = System.Drawing.Color.White;
            this.trackCountTextBox.Location = new System.Drawing.Point(279, 122);
            this.trackCountTextBox.Name = "trackCountTextBox";
            this.trackCountTextBox.ReadOnly = true;
            this.trackCountTextBox.Size = new System.Drawing.Size(81, 23);
            this.trackCountTextBox.TabIndex = 18;
            this.trackCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // slashLabel
            // 
            this.slashLabel.AutoSize = true;
            this.slashLabel.BackColor = System.Drawing.Color.Transparent;
            this.slashLabel.ForeColor = System.Drawing.Color.White;
            this.slashLabel.Location = new System.Drawing.Point(258, 122);
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.Size = new System.Drawing.Size(15, 19);
            this.slashLabel.TabIndex = 17;
            this.slashLabel.Text = "/";
            // 
            // musicComment
            // 
            this.musicComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicComment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicComment.ForeColor = System.Drawing.Color.White;
            this.musicComment.Location = new System.Drawing.Point(8, 180);
            this.musicComment.Multiline = true;
            this.musicComment.Name = "musicComment";
            this.musicComment.ReadOnly = true;
            this.musicComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.musicComment.Size = new System.Drawing.Size(352, 58);
            this.musicComment.TabIndex = 13;
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.BackColor = System.Drawing.Color.Transparent;
            this.CommentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentLabel.ForeColor = System.Drawing.Color.White;
            this.CommentLabel.Location = new System.Drawing.Point(6, 151);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(75, 19);
            this.CommentLabel.TabIndex = 12;
            this.CommentLabel.Text = "Comment:";
            // 
            // musicGenre
            // 
            this.musicGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicGenre.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicGenre.ForeColor = System.Drawing.Color.White;
            this.musicGenre.Location = new System.Drawing.Point(172, 151);
            this.musicGenre.Name = "musicGenre";
            this.musicGenre.ReadOnly = true;
            this.musicGenre.Size = new System.Drawing.Size(188, 23);
            this.musicGenre.TabIndex = 11;
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.BackColor = System.Drawing.Color.Transparent;
            this.GenreLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLabel.ForeColor = System.Drawing.Color.White;
            this.GenreLabel.Location = new System.Drawing.Point(114, 151);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(52, 19);
            this.GenreLabel.TabIndex = 10;
            this.GenreLabel.Text = "Genre:";
            // 
            // musicTrack
            // 
            this.musicTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicTrack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicTrack.ForeColor = System.Drawing.Color.White;
            this.musicTrack.Location = new System.Drawing.Point(172, 122);
            this.musicTrack.Name = "musicTrack";
            this.musicTrack.ReadOnly = true;
            this.musicTrack.Size = new System.Drawing.Size(80, 23);
            this.musicTrack.TabIndex = 9;
            this.musicTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackLabel
            // 
            this.TrackLabel.AutoSize = true;
            this.TrackLabel.BackColor = System.Drawing.Color.Transparent;
            this.TrackLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackLabel.ForeColor = System.Drawing.Color.White;
            this.TrackLabel.Location = new System.Drawing.Point(114, 122);
            this.TrackLabel.Name = "TrackLabel";
            this.TrackLabel.Size = new System.Drawing.Size(47, 19);
            this.TrackLabel.TabIndex = 8;
            this.TrackLabel.Text = "Track:";
            // 
            // musicYear
            // 
            this.musicYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicYear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicYear.ForeColor = System.Drawing.Color.White;
            this.musicYear.Location = new System.Drawing.Point(172, 93);
            this.musicYear.Name = "musicYear";
            this.musicYear.ReadOnly = true;
            this.musicYear.Size = new System.Drawing.Size(188, 23);
            this.musicYear.TabIndex = 7;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.BackColor = System.Drawing.Color.Transparent;
            this.YearLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLabel.ForeColor = System.Drawing.Color.White;
            this.YearLabel.Location = new System.Drawing.Point(114, 93);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(41, 19);
            this.YearLabel.TabIndex = 6;
            this.YearLabel.Text = "Year:";
            // 
            // musicAlbum
            // 
            this.musicAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicAlbum.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicAlbum.ForeColor = System.Drawing.Color.White;
            this.musicAlbum.Location = new System.Drawing.Point(172, 64);
            this.musicAlbum.Name = "musicAlbum";
            this.musicAlbum.ReadOnly = true;
            this.musicAlbum.Size = new System.Drawing.Size(188, 23);
            this.musicAlbum.TabIndex = 5;
            // 
            // musicArtist
            // 
            this.musicArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicArtist.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicArtist.ForeColor = System.Drawing.Color.White;
            this.musicArtist.Location = new System.Drawing.Point(172, 35);
            this.musicArtist.Name = "musicArtist";
            this.musicArtist.ReadOnly = true;
            this.musicArtist.Size = new System.Drawing.Size(188, 23);
            this.musicArtist.TabIndex = 3;
            // 
            // musicTitle
            // 
            this.musicTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.musicTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicTitle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicTitle.ForeColor = System.Drawing.Color.White;
            this.musicTitle.Location = new System.Drawing.Point(172, 6);
            this.musicTitle.Name = "musicTitle";
            this.musicTitle.ReadOnly = true;
            this.musicTitle.Size = new System.Drawing.Size(188, 23);
            this.musicTitle.TabIndex = 1;
            // 
            // AlbumLabel
            // 
            this.AlbumLabel.AutoSize = true;
            this.AlbumLabel.BackColor = System.Drawing.Color.Transparent;
            this.AlbumLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumLabel.ForeColor = System.Drawing.Color.White;
            this.AlbumLabel.Location = new System.Drawing.Point(114, 64);
            this.AlbumLabel.Name = "AlbumLabel";
            this.AlbumLabel.Size = new System.Drawing.Size(54, 19);
            this.AlbumLabel.TabIndex = 4;
            this.AlbumLabel.Text = "Album:";
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.BackColor = System.Drawing.Color.Transparent;
            this.ArtistLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistLabel.ForeColor = System.Drawing.Color.White;
            this.ArtistLabel.Location = new System.Drawing.Point(114, 35);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(48, 19);
            this.ArtistLabel.TabIndex = 2;
            this.ArtistLabel.Text = "Artist:";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(114, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(42, 19);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title:";
            // 
            // albumArtPicBox
            // 
            this.albumArtPicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.albumArtPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.albumArtPicBox.Location = new System.Drawing.Point(8, 6);
            this.albumArtPicBox.Name = "albumArtPicBox";
            this.albumArtPicBox.Size = new System.Drawing.Size(100, 100);
            this.albumArtPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.albumArtPicBox.TabIndex = 0;
            this.albumArtPicBox.TabStop = false;
            // 
            // fileInfoPage
            // 
            this.fileInfoPage.BackColor = System.Drawing.Color.Black;
            this.fileInfoPage.Controls.Add(this.durationTextBox);
            this.fileInfoPage.Controls.Add(this.durationLabel);
            this.fileInfoPage.Controls.Add(this.sourceTextBox);
            this.fileInfoPage.Controls.Add(this.createdTextBox);
            this.fileInfoPage.Controls.Add(this.createdLabel);
            this.fileInfoPage.Controls.Add(this.VideoSizeTextBox);
            this.fileInfoPage.Controls.Add(this.VideoSizeLabel);
            this.fileInfoPage.Controls.Add(this.FileNameTextBox);
            this.fileInfoPage.Controls.Add(this.FileNameLabel);
            this.fileInfoPage.Controls.Add(this.FileSizeTextBox);
            this.fileInfoPage.Controls.Add(this.FileTypeTextBox);
            this.fileInfoPage.Controls.Add(this.FileSizeLabel);
            this.fileInfoPage.Controls.Add(this.FileTypeLabel);
            this.fileInfoPage.Controls.Add(this.Label1);
            this.fileInfoPage.Location = new System.Drawing.Point(4, 28);
            this.fileInfoPage.Name = "fileInfoPage";
            this.fileInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileInfoPage.Size = new System.Drawing.Size(366, 244);
            this.fileInfoPage.TabIndex = 1;
            this.fileInfoPage.Text = "File Info";
            this.fileInfoPage.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPages_Paint);
            // 
            // durationTextBox
            // 
            this.durationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.durationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.durationTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationTextBox.ForeColor = System.Drawing.Color.White;
            this.durationTextBox.Location = new System.Drawing.Point(90, 151);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.ReadOnly = true;
            this.durationTextBox.Size = new System.Drawing.Size(270, 23);
            this.durationTextBox.TabIndex = 11;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoEllipsis = true;
            this.durationLabel.AutoSize = true;
            this.durationLabel.BackColor = System.Drawing.Color.Transparent;
            this.durationLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.ForeColor = System.Drawing.Color.White;
            this.durationLabel.Location = new System.Drawing.Point(6, 151);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(69, 19);
            this.durationLabel.TabIndex = 10;
            this.durationLabel.Text = "Duration:";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.sourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.ForeColor = System.Drawing.Color.White;
            this.sourceTextBox.Location = new System.Drawing.Point(90, 180);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ReadOnly = true;
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(270, 58);
            this.sourceTextBox.TabIndex = 13;
            // 
            // createdTextBox
            // 
            this.createdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.createdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.createdTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdTextBox.ForeColor = System.Drawing.Color.White;
            this.createdTextBox.Location = new System.Drawing.Point(90, 122);
            this.createdTextBox.Name = "createdTextBox";
            this.createdTextBox.ReadOnly = true;
            this.createdTextBox.Size = new System.Drawing.Size(270, 23);
            this.createdTextBox.TabIndex = 9;
            // 
            // createdLabel
            // 
            this.createdLabel.AutoEllipsis = true;
            this.createdLabel.AutoSize = true;
            this.createdLabel.BackColor = System.Drawing.Color.Transparent;
            this.createdLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdLabel.ForeColor = System.Drawing.Color.White;
            this.createdLabel.Location = new System.Drawing.Point(6, 122);
            this.createdLabel.Name = "createdLabel";
            this.createdLabel.Size = new System.Drawing.Size(64, 19);
            this.createdLabel.TabIndex = 8;
            this.createdLabel.Text = "Created:";
            this.createdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VideoSizeTextBox
            // 
            this.VideoSizeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.VideoSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoSizeTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoSizeTextBox.ForeColor = System.Drawing.Color.White;
            this.VideoSizeTextBox.Location = new System.Drawing.Point(90, 93);
            this.VideoSizeTextBox.Name = "VideoSizeTextBox";
            this.VideoSizeTextBox.ReadOnly = true;
            this.VideoSizeTextBox.Size = new System.Drawing.Size(270, 23);
            this.VideoSizeTextBox.TabIndex = 7;
            // 
            // VideoSizeLabel
            // 
            this.VideoSizeLabel.AutoEllipsis = true;
            this.VideoSizeLabel.AutoSize = true;
            this.VideoSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.VideoSizeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoSizeLabel.ForeColor = System.Drawing.Color.White;
            this.VideoSizeLabel.Location = new System.Drawing.Point(6, 93);
            this.VideoSizeLabel.Name = "VideoSizeLabel";
            this.VideoSizeLabel.Size = new System.Drawing.Size(79, 19);
            this.VideoSizeLabel.TabIndex = 6;
            this.VideoSizeLabel.Text = "Video Size:";
            this.VideoSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNameTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameTextBox.ForeColor = System.Drawing.Color.White;
            this.FileNameTextBox.Location = new System.Drawing.Point(90, 6);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.ReadOnly = true;
            this.FileNameTextBox.Size = new System.Drawing.Size(270, 23);
            this.FileNameTextBox.TabIndex = 1;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoEllipsis = true;
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.ForeColor = System.Drawing.Color.White;
            this.FileNameLabel.Location = new System.Drawing.Point(6, 6);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(78, 19);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "File Name:";
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileSizeTextBox
            // 
            this.FileSizeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FileSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileSizeTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeTextBox.ForeColor = System.Drawing.Color.White;
            this.FileSizeTextBox.Location = new System.Drawing.Point(90, 64);
            this.FileSizeTextBox.Name = "FileSizeTextBox";
            this.FileSizeTextBox.ReadOnly = true;
            this.FileSizeTextBox.Size = new System.Drawing.Size(270, 23);
            this.FileSizeTextBox.TabIndex = 5;
            // 
            // FileTypeTextBox
            // 
            this.FileTypeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FileTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileTypeTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypeTextBox.ForeColor = System.Drawing.Color.White;
            this.FileTypeTextBox.Location = new System.Drawing.Point(90, 35);
            this.FileTypeTextBox.Name = "FileTypeTextBox";
            this.FileTypeTextBox.ReadOnly = true;
            this.FileTypeTextBox.Size = new System.Drawing.Size(270, 23);
            this.FileTypeTextBox.TabIndex = 3;
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.AutoEllipsis = true;
            this.FileSizeLabel.AutoSize = true;
            this.FileSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileSizeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeLabel.ForeColor = System.Drawing.Color.White;
            this.FileSizeLabel.Location = new System.Drawing.Point(6, 64);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(65, 19);
            this.FileSizeLabel.TabIndex = 4;
            this.FileSizeLabel.Text = "File Size:";
            this.FileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.AutoEllipsis = true;
            this.FileTypeLabel.AutoSize = true;
            this.FileTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileTypeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypeLabel.ForeColor = System.Drawing.Color.White;
            this.FileTypeLabel.Location = new System.Drawing.Point(6, 35);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(70, 19);
            this.FileTypeLabel.TabIndex = 2;
            this.FileTypeLabel.Text = "File Type:";
            this.FileTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(6, 180);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 19);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Source:";
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
            this.closeButton.Location = new System.Drawing.Point(147, 306);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 27);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // durationTimer
            // 
            this.durationTimer.Interval = 250;
            // 
            // MediaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(374, 342);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MediaInfo";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Info";
            this.Load += new System.EventHandler(this.MediaInfo_Load);
            this.mainTabControl.ResumeLayout(false);
            this.mediaInfoPage.ResumeLayout(false);
            this.mediaInfoPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtPicBox)).EndInit();
            this.fileInfoPage.ResumeLayout(false);
            this.fileInfoPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mediaInfoPage;
        private System.Windows.Forms.TabPage fileInfoPage;
        private System.Windows.Forms.Button closeButton;
        internal System.Windows.Forms.TextBox musicComment;
        internal System.Windows.Forms.Label CommentLabel;
        internal System.Windows.Forms.TextBox musicGenre;
        internal System.Windows.Forms.Label GenreLabel;
        internal System.Windows.Forms.TextBox musicTrack;
        internal System.Windows.Forms.Label TrackLabel;
        internal System.Windows.Forms.TextBox musicYear;
        internal System.Windows.Forms.Label YearLabel;
        internal System.Windows.Forms.TextBox musicAlbum;
        internal System.Windows.Forms.TextBox musicArtist;
        internal System.Windows.Forms.TextBox musicTitle;
        internal System.Windows.Forms.Label AlbumLabel;
        internal System.Windows.Forms.Label ArtistLabel;
        internal System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox albumArtPicBox;
        internal System.Windows.Forms.TextBox VideoSizeTextBox;
        internal System.Windows.Forms.Label VideoSizeLabel;
        internal System.Windows.Forms.TextBox FileNameTextBox;
        internal System.Windows.Forms.Label FileNameLabel;
        internal System.Windows.Forms.TextBox FileSizeTextBox;
        internal System.Windows.Forms.TextBox FileTypeTextBox;
        internal System.Windows.Forms.Label FileSizeLabel;
        internal System.Windows.Forms.Label FileTypeLabel;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox createdTextBox;
        internal System.Windows.Forms.Label createdLabel;
        internal System.Windows.Forms.TextBox sourceTextBox;
        internal System.Windows.Forms.TextBox trackCountTextBox;
        private System.Windows.Forms.Label slashLabel;
        private System.Windows.Forms.Timer durationTimer;
        internal System.Windows.Forms.TextBox durationTextBox;
        internal System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label picDemensionLabel;
    }
}