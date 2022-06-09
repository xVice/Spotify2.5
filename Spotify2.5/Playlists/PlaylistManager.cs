using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Spotify2._5.Playlists
{
    public static class PlaylistManager
    {
        private static List<Playlist> playlists = new List<Playlist>();
        public static Dictionary<string, string> allSongs = new Dictionary<string, string>();

        public static void LoadPlaylistsFromDir(string dir)
        {
            foreach (string playlistJsonDir in Directory.GetFiles(dir, "*.json"))
            {
                var playlist = JsonConvert.DeserializeObject<Playlist>(File.ReadAllText(playlistJsonDir));
                foreach (var songJson in playlist.songJsonPaths)
                {
                    var song = JsonConvert.DeserializeObject<Song>(File.ReadAllText(songJson));
                    if (!allSongs.ContainsKey(song.songName))
                    {
                        allSongs.Add(song.songName, song.songPath);
                    }
                }
                playlist.SafePlaylistToFile("./playlists/" + playlist.name + ".json");
                playlists.Add(playlist);
            }
        }

        public static Song GetSongByName(string tSongName)
        {
            foreach(string songName in allSongs.Keys)
            {
                if (songName.Equals(tSongName))
                {
                    foreach(Playlist playlist in playlists)
                    {
                        foreach(string songJson in playlist.songJsonPaths)
                        {
                            var song = JsonConvert.DeserializeObject<Song>(File.ReadAllText(songJson));
                            if (song.songName.Equals(tSongName))
                            {
                                return song;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static void RefreshAllSongs()
        {
            allSongs.Clear();
            foreach(Playlist playlist in playlists)
            {
                foreach (var songJson in playlist.songJsonPaths)
                {
                    var song = JsonConvert.DeserializeObject<Song>(File.ReadAllText(songJson));
                    if (!allSongs.ContainsKey(song.songName))
                    {
                        allSongs.Add(song.songName, song.songPath);
                    }
                }
            }
        }

        public static void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }

        public static void DeletePlaylist(Playlist playlist)
        {
            if (playlists.Contains(playlist))
            {
                playlists.Remove(playlist);
            }
        }

        public static Playlist GetPlaylistByName(string playlistName)
        {
            foreach (Playlist playlist in playlists)
            {
                if (playlist.name.Equals(playlistName))
                {
                    return playlist;
                }
            }
            return null;
        }

        public static List<Playlist> GetPlayLists()
        {
            return playlists;
        }
    }
}
