using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface IArtistService
    {
        List<Artist> GetAllArtists();
        Task AddArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        void DeleteArtist(int id);
        bool ArtistExists(int id);
        Artist GetArtistById(int id);
        List<Album> GetAllAlbums();
        List<SongArtist> GetAllSongArtists();
    }
}
