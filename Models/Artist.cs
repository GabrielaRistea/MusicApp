using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Music_App.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? ArtistImage { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        [DisplayName("Imagine")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public ICollection<SongArtist> SongArtists { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
