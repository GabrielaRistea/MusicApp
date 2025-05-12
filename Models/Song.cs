using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Link { get; set; }

        [ForeignKey(nameof(Album))]
        public int? IdAlbum { get; set; }
        public Album? Album { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
        public ICollection<SongArtist> SongArtists { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
