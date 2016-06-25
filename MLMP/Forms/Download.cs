using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FileDownloaderApp;

namespace MLITEMEDIAPLAYER.Forms
{
    public partial class Download : DevComponents.DotNetBar.Metro.MetroForm
    {
        private FileDownloader downloader = new FileDownloader();
        private string URL, saveDir;
        private bool finishedDownloading = false;

        public Download(string tempURL, string tempSaveDir)
        {
            InitializeComponent();
            URL = tempURL; saveDir = tempSaveDir;

            downloader.ProgressChanged += new EventHandler(downloader_ProgressChanged);
            downloader.FileDownloadAttempting += new EventHandler(downloader_FileDownloadAttempting);
            downloader.FileDownloadStarted += new EventHandler(downloader_FileDownloadStarted);
            downloader.Completed += new EventHandler(downloader_Completed);
            downloader.CancelRequested += new EventHandler(downloader_CancelRequested);
            downloader.DeletingFilesAfterCancel += new EventHandler(downloader_DeletingFilesAfterCancel);
            downloader.Canceled += new EventHandler(downloader_Canceled);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            Graphics formGraphics = e.Graphics;
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 61, 61, 61), Color.Black, LinearGradientMode.Vertical);
            formGraphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void Download_Load(object sender, EventArgs e)
        {
            // set downloader options
            downloader.SupportsProgress = true;
            downloader.DeleteCompletedFilesAfterCancel = true;
            // set download directory
            downloader.LocalDirectory = saveDir;
            // add files
            downloader.Files.Add(new FileDownloader.FileInfo(URL));
            // start the downloader
            downloader.Start();
        }

        private void Download_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finishedDownloading) return;
            if (downloader.HasBeenCanceled == false && MessageBox.Show("Cancel downloading \"" + System.IO.Path.GetFileName(URL) + "\"?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                e.Cancel = true;
                downloader.Stop(true);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var process = new Process {
                StartInfo = {FileName = Application.ExecutablePath, Arguments = saveDir} };
            process.Start();
            this.Close();
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            var process = new Process {
                StartInfo = {FileName = "explorer.exe", Arguments = "/select,\"" + saveDir + '\"', WindowStyle = ProcessWindowStyle.Normal} };
            process.Start();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (finishedDownloading)
                this.Close();
            else
                downloader.Stop(true);
        }

        // Occurs every time of block of data has been downloaded, and can be used to display the progress with
        // Note that you can also create a timer, and display the progress every certain interval
        // Also note that the progress properties return a size in bytes, which is not really user friendly to display
        //      The FileDownloader class provides static functions to format these byte amounts to a more readible format, either in binary or decimal notation 
        private void downloader_ProgressChanged(object sender, EventArgs e)
        {
            if (downloader.SupportsProgress) {
                this.Text = downloader.CurrentFilePercentage().ToString("###.0") + "% - Downloading \"" + downloader.CurrentFile.Name + "\"...";
                speedTextBox.Text = FileDownloader.FormatSizeBinary(downloader.DownloadSpeed);
                downloadBar.Value = Convert.ToInt32(downloader.TotalPercentage());
            }
        }

        // This will be shown when the request for the file is made, before the download starts (or fails)
        private void downloader_FileDownloadAttempting(object sender, EventArgs e)
        {
            statusLabel.Text = "Starting \"" + downloader.CurrentFile.Name + "\"...";
        }

        // Display of the file info after the download started
        private void downloader_FileDownloadStarted(object sender, EventArgs e)
        {
            statusLabel.Text = "Downloading " + downloader.CurrentFile.Name + "...";
            fileNameTextBox.Text = downloader.CurrentFile.Name;
            fileSizeTextBox.Text = FileDownloader.FormatSizeBinary(downloader.CurrentFileSize);
            saveToTextBox.Text = downloader.CurrentFile.Path;
        }

        // Display of a completion message
        private void downloader_Completed(object sender, EventArgs e)
        {
            this.Text = "Download complete";
            statusLabel.Text = '\"' + downloader.CurrentFile.Name + "\" has finished downloading";
            openButton.Enabled = true;
            openFolderButton.Enabled = true;
            cancelButton.Text = "&Close";
            finishedDownloading = true;
            if (closeCheckBox.Checked) this.Close();
        }

        // Show a message that the downloads are being canceled - all files downloaded will be deleted and the current ones will be aborted
        private void downloader_CancelRequested(object sender, EventArgs e)
        {
            this.Text = "Canceling download...";
            statusLabel.Text = "Canceling download...";
        }

        // Show a message that the downloads are being canceled - all files downloaded will be deleted and the current ones will be aborted
        private void downloader_DeletingFilesAfterCancel(object sender, EventArgs e)
        {
            this.Text = "Canceling download...";
            statusLabel.Text = "Canceling download...";
        }

        // Show a message saying the downloads have been canceled
        private void downloader_Canceled(object sender, EventArgs e)
        {
            this.Text = "Download canceled";
            statusLabel.Text = "Download canceled";
            this.Close();
        }
    }
}
