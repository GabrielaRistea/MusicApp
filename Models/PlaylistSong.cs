using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class PlaylistSong
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Playlist))]
        public int IdPlaylist { get; set; }
        public Playlist Playlist { get; set; }

        [ForeignKey(nameof(Song))]
        public int IdSong { get; set; }
        public Song Song { get; set; }
    }
}
