using Music_App.Models;
using System.Xml.Linq;

namespace Music_App.Repositories.Interfaces
{
    public interface ISongRepository
    {
        IEnumerable<Song> GetAll();

        Song GetById( int id);

        Song GetByIdWithRelatedEntities(int id);

        bool SongExists (int id);
        void Create (Song song);
        void Update (Song song);
        void Delete (Song song);
        void Save();

        List<SongArtist> GetAllSongArtists();
        List<SongGenre> GetAllSongGenres();
        List<Album> GetAllAlbums();
        List<PlaylistSong> GetAllPlaylistSongs();
        List<Review> GetAllReviews();
        List<Song> GetSongByAlbum(int albumId);
    }
}
