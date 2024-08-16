namespace YTDLQuickGui {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tb_ytdl = new TextBox();
            tb_ytlink = new TextBox();
            cb_playlist = new CheckBox();
            btn_download = new Button();
            btn_open = new Button();
            tb_ffmpeg = new TextBox();
            btn_install = new Button();
            statusStrip1 = new StatusStrip();
            lbl_statusbar = new ToolStripStatusLabel();
            progbar = new ToolStripProgressBar();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_ytdl
            // 
            tb_ytdl.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_ytdl.Location = new Point(12, 12);
            tb_ytdl.Name = "tb_ytdl";
            tb_ytdl.PlaceholderText = "path to ytdl.exe";
            tb_ytdl.Size = new Size(269, 23);
            tb_ytdl.TabIndex = 0;
            // 
            // tb_ytlink
            // 
            tb_ytlink.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_ytlink.Location = new Point(12, 70);
            tb_ytlink.Name = "tb_ytlink";
            tb_ytlink.PlaceholderText = "YT Link";
            tb_ytlink.Size = new Size(269, 23);
            tb_ytlink.TabIndex = 1;
            // 
            // cb_playlist
            // 
            cb_playlist.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_playlist.AutoSize = true;
            cb_playlist.Location = new Point(12, 99);
            cb_playlist.Name = "cb_playlist";
            cb_playlist.Size = new Size(139, 19);
            cb_playlist.TabIndex = 2;
            cb_playlist.Text = "Download as playlist?";
            cb_playlist.UseVisualStyleBackColor = true;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(12, 124);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(75, 23);
            btn_download.TabIndex = 3;
            btn_download.Text = "download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // btn_open
            // 
            btn_open.Location = new Point(93, 124);
            btn_open.Name = "btn_open";
            btn_open.Size = new Size(84, 23);
            btn_open.TabIndex = 4;
            btn_open.Text = "open folder";
            btn_open.UseVisualStyleBackColor = true;
            // 
            // tb_ffmpeg
            // 
            tb_ffmpeg.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_ffmpeg.Location = new Point(12, 41);
            tb_ffmpeg.Name = "tb_ffmpeg";
            tb_ffmpeg.PlaceholderText = "path to ffmpeg.exe";
            tb_ffmpeg.Size = new Size(269, 23);
            tb_ffmpeg.TabIndex = 5;
            // 
            // btn_install
            // 
            btn_install.Location = new Point(183, 124);
            btn_install.Name = "btn_install";
            btn_install.Size = new Size(95, 23);
            btn_install.TabIndex = 6;
            btn_install.Text = "install for me";
            btn_install.UseVisualStyleBackColor = true;
            btn_install.Click += btn_install_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { progbar, lbl_statusbar });
            statusStrip1.Location = new Point(0, 154);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(294, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_statusbar
            // 
            lbl_statusbar.Name = "lbl_statusbar";
            lbl_statusbar.Size = new Size(39, 17);
            lbl_statusbar.Text = "Status";
            lbl_statusbar.TextAlign = ContentAlignment.MiddleRight;
            // 
            // progbar
            // 
            progbar.Name = "progbar";
            progbar.Size = new Size(100, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 176);
            Controls.Add(statusStrip1);
            Controls.Add(btn_install);
            Controls.Add(tb_ffmpeg);
            Controls.Add(btn_open);
            Controls.Add(btn_download);
            Controls.Add(cb_playlist);
            Controls.Add(tb_ytlink);
            Controls.Add(tb_ytdl);
            Icon = (Icon) resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Quick ytdl";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_ytdl;
        private TextBox tb_ytlink;
        private CheckBox cb_playlist;
        private Button btn_download;
        private Button btn_open;
        private TextBox tb_ffmpeg;
        private Button btn_install;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_statusbar;
        private ToolStripProgressBar progbar;
    }
}
