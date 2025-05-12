using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface ISongService
    {
        Song GetSongById(int id);
        void AddSong(Song song);
        void UpdateSong(Song song);
        void DeleteSong(int id);
        Song GetSongAndRelatedById(int id);
        List<Song> GetAllSongs();
        List<SongArtist> GetAllSongArtists();
        List<SongGenre> GetAllSongGenres();
        List<Album> GetAllAlbums();
        List<PlaylistSong> GetAllPlaylistSongs();
        List<Review> GetAllReviews();
        bool SongExists(int id);
        List<Song> GetAllSongsByAlbum(int albumId);
    }
}
