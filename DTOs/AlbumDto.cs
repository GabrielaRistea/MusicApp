using Music_App.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Music_App.DTOs
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public byte[]? Image { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
