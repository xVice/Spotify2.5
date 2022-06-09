using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spotify2._5.Playlists
{
    public class Playlist
    {
        public string playListDir;
        public string name { get; set; }
        public string author { get; set; }
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public List<string> songJsonPaths { get; set; } = new List<string>();

        public void AddSongWithDir(string dir, string author)
        {
            //songpaths.Add(Path.GetFullPath(dir));
            var tbaSong = new Song();
            tbaSong.songPathJson = @"./Songs/" + Path.GetFileName(dir).Replace(".", "") + ".json";
            tbaSong.songPath = Path.GetFullPath(dir);
            tbaSong.songName = Path.GetFileName(dir);
            tbaSong.author = author;
            tbaSong.description = "Description";
            tbaSong.playlistNames.Add(name);
            tbaSong.isFav = false;
            songJsonPaths.Add(tbaSong.songPathJson);
            tbaSong.SaveSong();
            //songList.Add(new Song(Path.GetFileName(dir), "Autor", "Description", Path.GetFullPath(dir)));
        }

        public void AddSong(Song song)
        {
            songJsonPaths.Add(song.songPathJson);
        }

        public void DeletePlaylist()
        {
            if (File.Exists(Path.GetFullPath(playListDir)))
            {
                PlaylistManager.DeletePlaylist(this);
                File.Delete(Path.GetFullPath(playListDir));
            }
        }

        public void DeleteSongByName(string name)
        {
            var song = PlaylistManager.GetSongByName(name);
            if (songJsonPaths.Contains(song.songPathJson))
            {
                songJsonPaths.Remove(song.songPathJson);
                song.playlistNames.Remove(name);
            }
            SafePlaylist();
        }

        public string GetSongByName(string name)
        {
            throw new NotImplementedException();
        }

        public void SafePlaylistToFile(string targetDir)
        {
            playListDir = targetDir;
            File.Delete(targetDir);
            File.WriteAllText(targetDir, JsonConvert.SerializeObject(this));
        }

        public void SafePlaylist()
        {
            File.Delete(playListDir);
            File.WriteAllText(playListDir, JsonConvert.SerializeObject(this));
        }
    }
}
