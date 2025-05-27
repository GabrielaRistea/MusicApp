using System.ComponentModel.DataAnnotations;

namespace Music_App.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Comm { get; set; }
        [Required]
        [Range(1, 5)]
        public float Rating { get; set; }
        public DateTime Date { get; set; }
        public int IdSong { get; set; }
        public string IdUser { get; set; }
        public string UserName { get; set; }
        public byte[] ProfilPicture { get; set; }

    }
}
