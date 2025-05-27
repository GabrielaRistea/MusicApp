using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Music_App.Models
{
    public class User : IdentityUser
    {
        public byte[]? ProfilPicture { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Imagine")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [ForeignKey(nameof(Subscription))]
        public int? IdSub { get; set; }
        public Subscription? Subscription { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
