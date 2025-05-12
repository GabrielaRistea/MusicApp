using Music_App.DTOs;
using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Task AddAlbumAsync(Album album);
        Task UpdateAlbumAsync(Album album);
        void DeleteAlbum(int id);
        bool AlbumExists(int id);
        Album GetAlbumById(int id);
        Album GetAlbumAndRelatedById(int id);
        List<Artist> GetAllArtists();
        List<Song> GetAllSongs();
        ArtistDTO GetAllAlbumsByArtist(int artistId);
    }
}
