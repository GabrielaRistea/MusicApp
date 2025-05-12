using Music_App.Models;

namespace Music_App.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Link { get; set; }
        public int? IdAlbum { get; set; }
        public ICollection<int> Genres { get; set; }
        public ICollection<string> GenreTypes { get; set; }
        public ICollection<int> Artists { get; set; }
        public ICollection<string> ArtistNames { get; set; }
    }
}
