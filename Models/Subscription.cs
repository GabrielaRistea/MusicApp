using System.ComponentModel.DataAnnotations;

namespace Music_App.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
