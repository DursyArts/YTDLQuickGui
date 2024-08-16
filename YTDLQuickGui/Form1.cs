using System.Reflection;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.ComponentModel;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;

namespace YTDLQuickGui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public string applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private void btn_download_Click(object sender, EventArgs e) {
            bool isPlaylist = cb_playlist.Checked;
            string ytdl = tb_ytdl.Text;
            string ffmpegBinPath = tb_ffmpeg.Text;
            string ytlink = tb_ytlink.Text;

            if(isPlaylist) {
                ProcessStartInfo ytdlInfo = new ProcessStartInfo();
                ytdlInfo.CreateNoWindow = false;
                ytdlInfo.UseShellExecute = false;
                ytdlInfo.FileName = ytdl;
                ytdlInfo.WindowStyle = ProcessWindowStyle.Normal;
                ytdlInfo.Arguments = $"--ffmpeg-location \"{ffmpegBinPath}\" -o \"\\%(playlist)s\\%(title)s.$(ext).s\" {ytlink}"; // todo: add -o flag to save videos into a folder named after the playlist.
                                                                                                                                  // done. 

                lbl_statusbar.Text = $"executing: {ytdlInfo.Arguments}";
                try {
                    using(Process ytdlProcess = Process.Start(ytdlInfo)) {
                        ytdlProcess.WaitForExit();
                    }
                } catch {
                    lbl_statusbar.Text = "Error while downloading";
                }
            } else {
                ProcessStartInfo ytdlInfo = new ProcessStartInfo();
                ytdlInfo.CreateNoWindow = false;
                ytdlInfo.UseShellExecute = false;
                ytdlInfo.FileName = ytdl;
                ytdlInfo.WindowStyle = ProcessWindowStyle.Normal;
                ytdlInfo.Arguments = $"--ffmpeg-location \"{ffmpegBinPath}\" {ytlink}";

                lbl_statusbar.Text = $"executing: {ytdlInfo.Arguments}";
                try {
                    using(Process ytdlProcess = Process.Start(ytdlInfo)) {
                        ytdlProcess.WaitForExit();
                    }
                } catch {
                    lbl_statusbar.Text = "Error while downloading";
                }
            }
        }

        private void btn_install_Click(object sender, EventArgs e) {
            string ytdlplink = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
            string ffmpeglink = "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip";

            using(WebClient client = new WebClient()) {
                lbl_statusbar.Text = "Downloading yt-dlp.exe";
                client.DownloadProgressChanged += progbar_DownloadProgressChanged;
                client.DownloadFileAsync(new System.Uri(ytdlplink), "yt-dlp.exe");
            }

            using(WebClient client = new WebClient()) {
                lbl_statusbar.Text = "Downloading ffmpeg.7z";
                client.DownloadProgressChanged += progbar_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadComplete;
                client.DownloadFileAsync(new System.Uri(ffmpeglink), "ffmpeg-master-latest-win64-gpl.zip");
            }
        }

        void progbar_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            progbar.Value = e.ProgressPercentage;
        }

        void client_DownloadComplete(object sender, AsyncCompletedEventArgs e) {
            if(e.Error == null) {
                lbl_statusbar.Text = "Complete";

                string ffmpegPath = applicationPath + "\\ffmpeg-master-latest-win64-gpl.zip";
                if(Path.Exists(ffmpegPath)) {
                    System.IO.Compression.ZipFile.ExtractToDirectory(ffmpegPath, applicationPath);
                }
                lbl_statusbar.Text = "extracted ffmpeg";

                File.Delete(ffmpegPath); // ? unsure if this is safe to do xd

                tb_ffmpeg.Text = applicationPath + "\\ffmpeg-master-latest-win64-gpl\\bin";
                tb_ytdl.Text = applicationPath + "\\yt-dlp.exe";
            } else {
                lbl_statusbar.Text = "Error" + e.Error.Message;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            WriteSettings("ffmpeg", tb_ffmpeg.Text);
            WriteSettings("ytdl", tb_ytdl.Text);
        }

        void WriteSettings(string key, string value) {
            try {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;
                if(settings[key] == null) {
                    settings.Add(key, value);
                } else {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            } catch(ConfigurationErrorsException) {
                lbl_statusbar.Text = "couldnt save config file";
            }
        }

        void ReadSettings() {
            try {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                tb_ytdl.Text = appSettings["ytdl"] ?? "";
                tb_ffmpeg.Text = appSettings["ffmpeg"] ?? "";
            } catch(ConfigurationErrorsException) {
                lbl_statusbar.Text = "no Config file could be loaded";
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            ReadSettings();
        }
    }
}
