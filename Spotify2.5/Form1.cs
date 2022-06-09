using System;
using System.Drawing;
using System.Windows.Forms;
using Spotify2._5.Playlists;
using Microsoft.VisualBasic;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Runtime.InteropServices;
using YoutubeExplode.Common;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Spotify2._5
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern bool ReleaseCapture();
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);

        private bool isMuted = false;
        private bool isPlaying = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            songnameLabel.Text = "";
            authorLabel.Text = "";
            PlaylistManager.LoadPlaylistsFromDir("./Playlists");
            mediaPlayer.uiMode = "none";
            mediaPlayer.Ctlcontrols.pause();
            mediaPlayer.settings.volume = volumeBar.Value;
            timer1.Interval = 1000;
            timer1.Start();
            foreach (string songName in PlaylistManager.allSongs.Keys)
            {
                songBox.Items.Add(songName);
            }
            ReloadPlaylists();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void playlistsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                ReloadSongs(selectedPlaylist);
                RefreshPanelColor(selectedPlaylist);
                bigPlayListLabel.Text = selectedPlaylist.name;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.play();
        }

        private void ReloadSongs(Playlist playlist)
        {
            songBox.Items.Clear();
            if (playlist.songJsonPaths != null)
            {
                foreach (string songNameJson in playlist.songJsonPaths)
                {
                    if (File.Exists(songNameJson))
                    {
                        Song song = JsonConvert.DeserializeObject<Song>(File.ReadAllText(songNameJson));
                        songBox.Items.Add(song.songName);
                    }
                }
            }
        }

        private void ReloadPlaylists()
        {
            playlistsBox.Items.Clear();
            foreach (Playlist playlist in PlaylistManager.GetPlayLists())
            {
                playlistsBox.Items.Add(playlist.name);
            }
        }

        private void aloneButton2_Click(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                DialogResult result = addsongDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedPlaylist.AddSongWithDir(addsongDialog.FileName, "Author");
                    ReloadSongs(selectedPlaylist);
                    selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
                }
            }
        }

        private void createPlaylistBut_Click(object sender, EventArgs e)
        {
            Playlist newPlayList = new Playlist();
            newPlayList.name = Interaction.InputBox("Setze hier denn namen der playlist fest!", "Set the playlists name", "playlist name");
            newPlayList.author = Interaction.InputBox("Setze hier denn autor der playlist fest!", "Set the playlists author", "authors name");
            newPlayList.r = 0;
            newPlayList.g = 204;
            newPlayList.b = 102;
            newPlayList.SafePlaylistToFile("./Playlists/" + newPlayList.name + ".json");
            PlaylistManager.AddPlaylist(newPlayList);
            ReloadPlaylists();
        }

        private void RefreshPanelColor(Playlist playlist)
        {
            playlistColor.BackColor = Color.FromArgb(playlist.r, playlist.g, playlist.b);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void playButton_Click_1(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                playButton.Image = Image.FromFile("./Icons/icons8_pause_button_60px.png");
                topPlayButton.Image = Image.FromFile("./Icons/icons8_pause_button_30px_1.png");
                isPlaying = false;
            }
            else
            {
                playButton.Image = Image.FromFile("./Icons/icons8_circled_play_60px_1.png");
                topPlayButton.Image = Image.FromFile("./Icons/icons8_circled_play_30px.png");
                isPlaying = true;
            }
            PlayOrPauseVideo();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                playButton.Image = Image.FromFile("./Icons/icons8_pause_button_60px.png");
                topPlayButton.Image = Image.FromFile("./Icons/icons8_pause_button_30px_1.png");
                isPlaying = false;
            }
            else
            {
                playButton.Image = Image.FromFile("./Icons/icons8_play_button_circled_60px_1.png");
                topPlayButton.Image = Image.FromFile("./Icons/icons8_circled_play_30px.png");
                isPlaying = true;
            }
        }

        private void PlayOrPauseVideo()
        {
            if (isPlaying)
                mediaPlayer.Ctlcontrols.play();
            else
                mediaPlayer.Ctlcontrols.stop();
        }

        private void songBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songBox.SelectedIndex >= 0)
            {
                songCover.Image = Image.FromFile("./Icons/icons8_audio_file_50px_1.png");
                Song selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
                ChangeHeartIcon(selectedSong);
                mediaPlayer.URL = selectedSong.songPath;
                PlayOrPauseVideo();
                songnameLabel.Text = selectedSong.songName;
                authorLabel.Text = selectedSong.author;
                if (File.Exists(selectedSong.imageLocation))
                {
                    songCover.Image = Image.FromFile(selectedSong.imageLocation);
                }
                else if (selectedSong.imageLocation != null)
                {
                    MessageBox.Show("Das cover des songs konnte nicht gefunden werden!", "FILE NOT FOUND!");
                }
            }
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            Playlist newPlayList = new Playlist();
            newPlayList.name = Interaction.InputBox("Setze hier denn namen der playlist fest!", "Set the playlists name", "playlist name");
            newPlayList.author = Interaction.InputBox("Setze hier denn autor der playlist fest!", "Set the playlists author", "authors name");
            newPlayList.r = 0;
            newPlayList.g = 204;
            newPlayList.b = 102;
            newPlayList.SafePlaylistToFile("./Playlists/" + newPlayList.name + ".json");
            PlaylistManager.AddPlaylist(newPlayList);
            ReloadPlaylists();
        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            songBox.Items.Clear();
            bigPlayListLabel.Text = "Favourites";
            playlistColor.BackColor = Color.FromArgb(0, 205, 102);
            foreach (string songPath in Directory.GetFiles("./Songs/", "*.json"))
            {
                var song = JsonConvert.DeserializeObject<Song>(File.ReadAllText(songPath));
                if (song.isFav)
                {
                    songBox.Items.Add(song.songName);
                }
            }
            /*
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                //Song currentSong = new Song();
                DialogResult songName = addsongDialog.ShowDialog();
                if (songName == DialogResult.OK)
                {
                    selectedPlaylist.AddSongWithDir(addsongDialog.FileName);
                    //currentSong.Name = Path.GetFileName(addsongDialog.FileName);
                    //currentSong.Url = Path.GetFullPath(addsongDialog.FileName);
                }
                DialogResult songImage = addImageToSongDialog.ShowDialog();
                if (songImage == DialogResult.OK)
                {
                    //currentSong.image = Image.FromFile(Path.GetFullPath(addImageToSongDialog.FileName));
                }
                //currentSong.Description = Interaction.InputBox("Setze hier die beschreibung der playlist fest!", "Set the playlists description", "playlist description");
                //selectedPlaylist.AddSong(currentSong, addsongDialog.FileName);
                selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
                ReloadSongs(selectedPlaylist);
            }
            */
        }

        private void favButtons_Click(object sender, EventArgs e)
        {

        }

        private void playlistColor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void dungeonTrackBar2_ValueChanged()
        {
            mediaPlayer.settings.volume = volumeBar.Value * 2;
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                string rgb = Interaction.InputBox("Setze hier die farbe der playlist fest!", "Set playlist color", "255 255 255");
                string[] rgbs = rgb.Split(' ');
                try
                {
                    int r = int.Parse(rgbs[0]);
                    int g = int.Parse(rgbs[1]);
                    int b = int.Parse(rgbs[2]);
                    if (r <= 255 || g <= 255 || b <= 255)
                    {
                        selectedPlaylist.r = r;
                        selectedPlaylist.g = g;
                        selectedPlaylist.b = b;
                        RefreshPanelColor(selectedPlaylist);
                        selectedPlaylist.SafePlaylist();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ein fehler ist aufgetreten!" + ex.Message, "ERROR!");
                }
            }
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                string name = Interaction.InputBox("Setze hier denn name der playlist fest", "Set playlist name", selectedPlaylist.name);
                selectedPlaylist.name = name;
                selectedPlaylist.SafePlaylist();
                ReloadPlaylists();
            }
        }

        private void changeAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                string author = Interaction.InputBox("Setze hier denn autor der playlist fest", "Set playlist author", selectedPlaylist.author);
                selectedPlaylist.author = author;
                selectedPlaylist.SafePlaylist();
                ReloadPlaylists();
            }
        }

        private void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                selectedPlaylist.DeletePlaylist();
                ReloadPlaylists();
            }
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            PlaylistManager.RefreshAllSongs();
            playlistsBox.SelectedIndex = -1;
            bigPlayListLabel.Text = "Home";
            playlistColor.BackColor = Color.FromArgb(192, 0, 192);
            songBox.Items.Clear();
            foreach (string song in PlaylistManager.allSongs.Keys)
            {
                songBox.Items.Add(song);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            playlistsBox.SelectedIndex = -1;
            songBox.Items.Clear();
            string searchTerm = Interaction.InputBox("Suchbegriff:", "Search song", "LX - California Dreamin");
            string searchResult = ClosestWord(searchTerm, PlaylistManager.allSongs.Keys.ToArray());
            songBox.Items.Add(searchResult);
            foreach (string song in PlaylistManager.allSongs.Keys.ToArray())
            {
                foreach (string word in searchTerm.Split(' '))
                {
                    if (song.ToLower().Contains(word.ToLower()) && !songBox.Items.Contains(word))
                    {
                        songBox.Items.Add(song);
                    }
                }
            }
        }

        public static string ClosestWord(string word, string[] terms)
        {
            string term = word.ToLower();
            List<string> list = terms.ToList();
            if (list.Contains(term))
                return list.Find(t => t.ToLower() == term);
            else
            {
                int[] counter = new int[terms.Length];
                for (int i = 0; i < terms.Length; i++)
                {
                    for (int x = 0; x < Math.Min(term.Length, terms[i].Length); x++)
                    {
                        int difference = Math.Abs(term[x] - terms[i][x]);
                        counter[i] += difference;
                    }
                }

                int min = counter.Min();
                int index = counter.ToList().FindIndex(t => t == min);
                return terms[index];
            }
        }

        private void trackBar_ValueChanged()
        {
            //mediaPlayer.Ctlcontrols.currentPosition = trackBar.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            isMuted = !isMuted;
            mediaPlayer.settings.mute = isMuted;
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            mediaPlayer.Ctlcontrols.currentPosition = trackBar.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar.Value = (int)mediaPlayer.Ctlcontrols.currentPosition;
            songTime.Text = mediaPlayer.Ctlcontrols.currentPositionString;
        }

        private void mediaPlayer_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            trackBar.Maximum = (int)mediaPlayer.currentMedia.duration;
            songDuration.Text = mediaPlayer.currentMedia.durationString;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Song selectedSong = PlaylistManager.GetSongByName(songnameLabel.Text);
            selectedSong.isFav = !selectedSong.isFav;
            selectedSong.SaveSong();
            ChangeHeartIcon(selectedSong);
        }

        private void ChangeHeartIcon(Song song)
        {
            if (songBox.SelectedIndex >= 0)
            {
                if (song.isFav)
                {
                    pictureBox4.Image = Image.FromFile("./Icons/icons8_heart_30px_1_green.png");
                }
                else
                {
                    pictureBox4.Image = Image.FromFile("./Icons/icons8_heart_30px_1.png");
                }
            }

        }

        private void changeAuthorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (songBox.SelectedIndex >= 0 && songBox.SelectedItems.Count == 1)
            {
                var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
                selectedSong.author = Interaction.InputBox("Setze hier denn autor des songs fest", "Set song author", selectedSong.author);
                selectedSong.SaveSong();
            }
            else if (songBox.SelectedItems.Count >= 0)
            {
                var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
                string author = Interaction.InputBox("Setze hier denn autor des songs fest", "Set song author", selectedSong.author);
                foreach (string song in songBox.SelectedItems)
                {
                    var curSong = PlaylistManager.GetSongByName(song.ToString());
                    curSong.author = author;
                }
            }
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songBox.SelectedIndex >= 0)
            {
                var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
                DialogResult songImage = addImageToSongDialog.ShowDialog();
                if (songImage == DialogResult.OK)
                {
                    selectedSong.imageLocation = Path.GetFullPath(addImageToSongDialog.FileName);
                }
                selectedSong.SaveSong();
            }
        }

        private void deleteSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
            var playlist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
            selectedSong.DeleteSong(playlist);
            selectedSong.SaveSong();
            songBox.Items.Remove(selectedSong.songName);
            //selectedSong.DeleteSong();
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
            var playlist = PlaylistManager.GetPlaylistByName(selectedSong.playlistName);
            playlistColor.BackColor = Color.FromArgb(playlist.r, playlist.g, playlist.b);
            bigPlayListLabel.Text = playlist.name;
            ReloadSongs(PlaylistManager.GetPlaylistByName(selectedSong.playlistName));
            */
        }







        //Youtube Downloader : YTDLMP3
        private async void youtubeDownloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var youtube = new YoutubeClient();
            string youtubevideo = Interaction.InputBox("Füge die youtube url unten ein!", "Youtube Downloader", "https://www.youtube.com/watch?v=5h6WKGlB8s8");
            // You can specify both video ID or URL
            var video = await youtube.Videos.GetAsync(youtubevideo);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubevideo);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"./Download/{video.Title}.{streamInfo.Container}");

            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                selectedPlaylist.AddSongWithDir("./Download/" + video.Title + "." + streamInfo.Container, video.Author.ToString());
                PlaylistManager.RefreshAllSongs();
                ReloadSongs(selectedPlaylist);
                selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
            }
        }

        //Youtube Downloader : YTDLMP4
        private async void adToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var youtube = new YoutubeClient();
            string youtubevideo = Interaction.InputBox("Füge die youtube url unten ein!", "Youtube Downloader", "https://www.youtube.com/watch?v=5h6WKGlB8s8");
            // You can specify both video ID or URL
            var video = await youtube.Videos.GetAsync(youtubevideo);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubevideo);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"./Download/{video.Title}.{streamInfo.Container}");

            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                selectedPlaylist.AddSongWithDir("./Download/" + video.Title + "." + streamInfo.Container, video.Author.ToString());
                PlaylistManager.RefreshAllSongs();
                ReloadSongs(selectedPlaylist);
                selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
            }
        }

        private async void downloadYoutubePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var youtube = new YoutubeClient();
            string youtubevideo = Interaction.InputBox("Füge die youtube playlist url unten ein!", "Youtube Downloader", "https://www.youtube.com/playlist?list=OLAK5uy_nGBDnkoKm5gKGiConNsvIK0qCBoAKIqnI");
            var videos = await youtube.Playlists.GetVideosAsync(youtubevideo);
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                foreach (var video in videos)
                {
                    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Url);
                    var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
                    await youtube.Videos.Streams.DownloadAsync(streamInfo, $"./Download/{video.Title}.{streamInfo.Container}");
                    selectedPlaylist.AddSongWithDir("./Download/" + video.Title + "." + streamInfo.Container, video.Author.ToString());
                }
                PlaylistManager.RefreshAllSongs();
                ReloadSongs(selectedPlaylist);
                selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
            }
        }

        private async void downloadYoutubePlaylistAsSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var youtube = new YoutubeClient();
            string youtubevideo = Interaction.InputBox("Füge die youtube playlist url unten ein!", "Youtube Downloader", "https://www.youtube.com/playlist?list=OLAK5uy_nGBDnkoKm5gKGiConNsvIK0qCBoAKIqnI");
            var videos = await youtube.Playlists.GetVideosAsync(youtubevideo);
            if (playlistsBox.SelectedIndex >= 0)
            {
                Playlist selectedPlaylist = PlaylistManager.GetPlaylistByName(playlistsBox.SelectedItem.ToString());
                foreach (var video in videos)
                {
                    try
                    {
                        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Url);
                        var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                        await youtube.Videos.Streams.DownloadAsync(streamInfo, $"./Download/{video.Title}.{streamInfo.Container}");
                        selectedPlaylist.AddSongWithDir("./Download/" + video.Title + "." + streamInfo.Container, video.Author.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Das video: " + video.Title + " konnte nicht runtergeladen werden.", "Youtube Download!");
                    }
                }
                PlaylistManager.RefreshAllSongs();
                ReloadSongs(selectedPlaylist);
                MessageBox.Show("Alle video wurden runtergeladen!", "Youtubt Download!");
                selectedPlaylist.SafePlaylistToFile("./Playlists/" + selectedPlaylist.name + ".json");
            }
        }

        private void mediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void addToPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void songBoxStrip_Opened(object sender, EventArgs e)
        {
            addToPlaylistToolStripMenuItem.DropDownItems.Clear();
            foreach (var playlist in PlaylistManager.GetPlayLists())
            {
                if (!addToPlaylistToolStripMenuItem.DropDownItems.ContainsKey(playlist.name))
                {
                    addToPlaylistToolStripMenuItem.DropDownItems.Add(playlist.name);
                }
            }
        }

        private void addToPlaylistToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var playlist = PlaylistManager.GetPlaylistByName(e.ClickedItem.Text);
            var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
            selectedSong.AddToPlaylist(playlist);
            selectedSong.SaveSong();
            //playlist.AddSong(selectedSong);
        }

        private void openInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedSong = PlaylistManager.GetSongByName(songBox.SelectedItem.ToString());
            SongInfoForm songInfo = new SongInfoForm(selectedSong);
            songInfo.Show();
        }
    }
}
