using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class SongArtist
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Song))]
        public int IdSong { get; set; }
        public Song Song { get; set; }

        [ForeignKey(nameof(Artist))]
        public int IdArtist { get; set; }
        public Artist Artist { get; set; }
    }
}
