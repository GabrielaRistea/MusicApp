using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Comm { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Song))]
        public int IdSong { get; set; }
        public Song Song { get; set; }
    }
}
