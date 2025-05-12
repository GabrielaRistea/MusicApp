using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class SongGenre
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Song))]
        public int IdSong { get; set; }
        public Song Song { get; set; }

        [ForeignKey(nameof(Genre))]
        public int IdGenre { get; set; }
        public Genre Genre { get; set; }
    }
}
