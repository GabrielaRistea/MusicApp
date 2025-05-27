using Music_App.Models;

namespace Music_App.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        IEnumerable<Playlist> GetAll();
        bool PlaylistExists(int id);
        void Create(Playlist playlist);
        void Update(Playlist playlist);
        void Delete(Playlist playlist);
        void Save();
        Playlist GetById(int id);
        IEnumerable<PlaylistSong> GetPlaylistSongsByUserId(string userId);
        Song GetSongById(int songId);
        bool PlaylistSongExists(int playlistId, int songId);
        PlaylistSong GetPlaylistSongById(int id);
        IEnumerable<Playlist> GetPlaylistsByUserId(string userId);
        IEnumerable<Playlist> GetByUserId(string userId);
        void AddPlaylistSong(PlaylistSong playlistSong);
        Playlist GetPlaylistWithSongs(int id);
        PlaylistSong GetPlaylistSong(int playlistId, int songId);
        void RemovePlaylistSong(PlaylistSong playlistSong);
    }
}
