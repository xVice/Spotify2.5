namespace Spotify2._5
{
    partial class SongInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongInfoForm));
            this.playlistColor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigSongNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.songDescLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.songDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            this.songPathBox = new System.Windows.Forms.TextBox();
            this.songAutorBox = new System.Windows.Forms.TextBox();
            this.playListNameBox = new System.Windows.Forms.TextBox();
            this.songNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.songCover = new System.Windows.Forms.PictureBox();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.playlistColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songCover)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistColor
            // 
            this.playlistColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.playlistColor.Controls.Add(this.pictureBox1);
            this.playlistColor.Controls.Add(this.panel1);
            this.playlistColor.Controls.Add(this.bigSongNameLabel);
            this.playlistColor.Location = new System.Drawing.Point(0, 0);
            this.playlistColor.Margin = new System.Windows.Forms.Padding(4);
            this.playlistColor.Name = "playlistColor";
            this.playlistColor.Size = new System.Drawing.Size(489, 46);
            this.playlistColor.TabIndex = 14;
            this.playlistColor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playlistColor_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Spotify2._5.Properties.Resources.icons8_Close_64px_1;
            this.pictureBox1.Location = new System.Drawing.Point(457, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 218);
            this.panel1.TabIndex = 15;
            // 
            // bigSongNameLabel
            // 
            this.bigSongNameLabel.AutoSize = true;
            this.bigSongNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigSongNameLabel.ForeColor = System.Drawing.Color.White;
            this.bigSongNameLabel.Location = new System.Drawing.Point(4, 5);
            this.bigSongNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bigSongNameLabel.MaximumSize = new System.Drawing.Size(450, 0);
            this.bigSongNameLabel.Name = "bigSongNameLabel";
            this.bigSongNameLabel.Size = new System.Drawing.Size(122, 30);
            this.bigSongNameLabel.TabIndex = 19;
            this.bigSongNameLabel.Text = "SongName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(119, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Song Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(119, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Song Autor:";
            // 
            // songDescLabel
            // 
            this.songDescLabel.AutoSize = true;
            this.songDescLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songDescLabel.ForeColor = System.Drawing.Color.White;
            this.songDescLabel.Location = new System.Drawing.Point(13, 160);
            this.songDescLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.songDescLabel.Name = "songDescLabel";
            this.songDescLabel.Size = new System.Drawing.Size(118, 17);
            this.songDescLabel.TabIndex = 25;
            this.songDescLabel.Text = "Song Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(119, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Playlist Name:";
            // 
            // songDescriptionBox
            // 
            this.songDescriptionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.songDescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songDescriptionBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songDescriptionBox.ForeColor = System.Drawing.Color.Gray;
            this.songDescriptionBox.Location = new System.Drawing.Point(16, 181);
            this.songDescriptionBox.Name = "songDescriptionBox";
            this.songDescriptionBox.Size = new System.Drawing.Size(461, 105);
            this.songDescriptionBox.TabIndex = 27;
            this.songDescriptionBox.Text = "";
            // 
            // hopeButton1
            // 
            this.hopeButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton1.Location = new System.Drawing.Point(430, 295);
            this.hopeButton1.Name = "hopeButton1";
            this.hopeButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(205)))), ((int)(((byte)(20)))));
            this.hopeButton1.Size = new System.Drawing.Size(47, 27);
            this.hopeButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(205)))), ((int)(((byte)(20)))));
            this.hopeButton1.TabIndex = 29;
            this.hopeButton1.Text = "Save";
            this.hopeButton1.TextColor = System.Drawing.Color.White;
            this.hopeButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton1.Click += new System.EventHandler(this.hopeButton1_Click);
            // 
            // songPathBox
            // 
            this.songPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.songPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songPathBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songPathBox.ForeColor = System.Drawing.Color.Gray;
            this.songPathBox.Location = new System.Drawing.Point(193, 113);
            this.songPathBox.Name = "songPathBox";
            this.songPathBox.Size = new System.Drawing.Size(258, 18);
            this.songPathBox.TabIndex = 30;
            // 
            // songAutorBox
            // 
            this.songAutorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.songAutorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songAutorBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songAutorBox.ForeColor = System.Drawing.Color.Gray;
            this.songAutorBox.Location = new System.Drawing.Point(201, 93);
            this.songAutorBox.Name = "songAutorBox";
            this.songAutorBox.Size = new System.Drawing.Size(278, 18);
            this.songAutorBox.TabIndex = 31;
            // 
            // playListNameBox
            // 
            this.playListNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.playListNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playListNameBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playListNameBox.ForeColor = System.Drawing.Color.Gray;
            this.playListNameBox.Location = new System.Drawing.Point(214, 74);
            this.playListNameBox.Name = "playListNameBox";
            this.playListNameBox.Size = new System.Drawing.Size(265, 18);
            this.playListNameBox.TabIndex = 32;
            // 
            // songNameBox
            // 
            this.songNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.songNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songNameBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songNameBox.ForeColor = System.Drawing.Color.Gray;
            this.songNameBox.Location = new System.Drawing.Point(201, 54);
            this.songNameBox.Name = "songNameBox";
            this.songNameBox.Size = new System.Drawing.Size(278, 18);
            this.songNameBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(119, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Song Name:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Spotify2._5.Properties.Resources.icons8_copy_24px;
            this.pictureBox2.Location = new System.Drawing.Point(457, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // songCover
            // 
            this.songCover.Image = global::Spotify2._5.Properties.Resources.icons8_audio_file_50px_1;
            this.songCover.Location = new System.Drawing.Point(11, 54);
            this.songCover.Margin = new System.Windows.Forms.Padding(4);
            this.songCover.Name = "songCover";
            this.songCover.Size = new System.Drawing.Size(100, 100);
            this.songCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.songCover.TabIndex = 15;
            this.songCover.TabStop = false;
            this.songCover.Click += new System.EventHandler(this.songCover_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openFileDialog1";
            // 
            // SongInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(489, 331);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.songNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playListNameBox);
            this.Controls.Add(this.songAutorBox);
            this.Controls.Add(this.songPathBox);
            this.Controls.Add(this.hopeButton1);
            this.Controls.Add(this.songDescriptionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.songDescLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.songCover);
            this.Controls.Add(this.playlistColor);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SongInfoForm";
            this.Text = "Song Info";
            this.Load += new System.EventHandler(this.SongInfoForm_Load);
            this.playlistColor.ResumeLayout(false);
            this.playlistColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel playlistColor;
        private System.Windows.Forms.Label bigSongNameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox songCover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label songDescLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox songDescriptionBox;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox songPathBox;
        private System.Windows.Forms.TextBox songAutorBox;
        private System.Windows.Forms.TextBox playListNameBox;
        private System.Windows.Forms.TextBox songNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
    }
}