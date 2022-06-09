using System;
using System.Drawing;
using System.Windows.Forms;
using Spotify2._5.Playlists;
using System.IO;
using System.Runtime.InteropServices;

namespace Spotify2._5
{
    public partial class SongInfoForm : Form
    {
        [DllImport("user32")]
        private static extern bool ReleaseCapture();
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);

        private Song song;
        public SongInfoForm(Song song)
        {
            InitializeComponent();
            this.song = song;
        }

        private void SongInfoForm_Load(object sender, EventArgs e)
        {
            songNameBox.Text = song.songName;
            bigSongNameLabel.Text = song.songName;
            songPathBox.Text = song.songPath;
            songAutorBox.Text = song.author;
            songDescriptionBox.Text = song.description;

            foreach (string playlistName in song.playlistNames)
            {
                playListNameBox.Text += playlistName + " ";
            }
            if (File.Exists(song.imageLocation))
            {
                songCover.Image = Image.FromFile(song.imageLocation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playlistColor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void songCover_Click(object sender, EventArgs e)
        {
            DialogResult image = openImageDialog.ShowDialog();
            if(image == DialogResult.OK)
            {
                songCover.Image = Image.FromFile(openImageDialog.FileName);
                song.imageLocation = Path.GetFullPath(openImageDialog.FileName);
            }
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            song.songName = songNameBox.Text;
            song.author = songAutorBox.Text;
            song.songPath = songPathBox.Text;
            song.description = songDescriptionBox.Text;
            song.SaveSong();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(songPathBox.Text);
        }
    }
}
