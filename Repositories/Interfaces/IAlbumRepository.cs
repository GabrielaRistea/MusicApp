using Music_App.Models;

namespace Music_App.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        bool AlbumExists(int id);
        void Create(Album album);
        void Update(Album album);
        void Delete(Album album);
        void Save();
        Album GetById(int id);
        Album GetByIdWithRelatedEntities(int id);
        List<Artist> GetAllArtists();
        List<Song> GetAllSongs();
        List<Album> GetAlbumsByArtist(int artistId);
    }
}
