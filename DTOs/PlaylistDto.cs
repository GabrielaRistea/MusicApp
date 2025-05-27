namespace Music_App.DTOs
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongDTO> SongDto { get; set; }
    }
}
