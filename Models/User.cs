using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Music_App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[]? ProfilPicture { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Imagine")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string Role { get; set; }

        [ForeignKey(nameof(Subscription))]
        public int IdSub { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
