using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Music_App.Models
{
    public class Album
    {
        [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Duration { get; set; }
            public byte[]? Image { get; set; }
            public DateTime ReleaseDate { get; set; }   
            [DataType(DataType.Upload)]
            [DisplayName("Imagine")]
            [NotMapped]
            public IFormFile ImageFile { get; set; }

            [ForeignKey(nameof(Artist))]
            public int IdArtist { get; set; }
            public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
