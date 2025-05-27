using Music_App.Models;
using Music_App.DTOs;

namespace Music_App.Services.Interfaces
{
    public interface IPlaylistService
    {
        List<Playlist> GetAllPlaylists();
        void AddPlaylist(Playlist playlist);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(int id);
        bool PlaylistExists(int id);
        Playlist GetPlaylistById(int id);
        List<Playlist> GetPlaylistsByUser(string userId);
        IEnumerable<Playlist> GetByUserId(string userId);
        Task<string> AddSongToPlaylistAsync(int playlistId, int songId);
        Task<bool> PlaylistSongExistsAsync(int playlistId, int songId);
        PlaylistSong GetPlaylistSongById(int id);
        PlaylistDto GetPlaylistDetails(int playlistId);
        Task<string> RemoveSongFromPlaylistAsync(int playlistId, int songId);
    }
}
