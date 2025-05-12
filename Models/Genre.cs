using System.ComponentModel.DataAnnotations;

namespace Music_App.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }
}
