using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Spotify2._5.Playlists
{
    public class Song
    {
        public string songPathJson { get; set; }
        public string songPath { get; set; }
        public string songName { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public List<string> playlistNames { get; set; } = new List<string>();
        public string imageLocation { get; set; }
        public bool isFav { get; set; }

        //geht besser
        public void SaveSong()
        {
            File.WriteAllText(songPathJson, JsonConvert.SerializeObject(this));
        }

        public void AddToPlaylist(Playlist playlist)
        {
            playlist.AddSong(this);
            playlistNames.Add(playlist.name);
        }

        public void DeleteSong(Playlist tPlaylist)
        {
            foreach(string playlistName in playlistNames)
            {
                if(playlistName.Equals(tPlaylist.name))
                {
                    tPlaylist.DeleteSongByName(songName);
                    tPlaylist.SafePlaylist();
                }
                else if(playlistName.Equals(tPlaylist.name) && playlistNames.Count == 1)
                {
                    if (File.Exists(songPathJson))
                        File.Delete(songPathJson);
                    if (File.Exists(songPath))
                        File.Delete(songPath);

                    tPlaylist.DeleteSongByName(songName);
                    tPlaylist.SafePlaylist();
                }
            }
        }
    }
}
