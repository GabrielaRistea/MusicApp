using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private MusicAppContext _context;
        public PlaylistRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Playlist> GetAll()
        {
            return _context.Playlists.ToList();
        }
        public void Create(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
        }
        public void Delete(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public bool PlaylistExists(int id)
        {
            return _context.Playlists.Any(p => p.Id == id);
        }

        public void Update(Playlist playlist)
        {
            _context.Playlists.Update(playlist);
        }
        public Playlist GetById(int id)
        {
            return _context.Playlists.FirstOrDefault(a => a.Id == id);
        }
        public Song GetSongById(int songId)
        {
            return _context.Songs.Find(songId);
        }
        public bool PlaylistSongExists(int playlistId, int songId)
        {
            return _context.PlaylistSongs.Any(wb => wb.IdPlaylist == playlistId && wb.IdSong == songId);
        }
        public IEnumerable<PlaylistSong> GetPlaylistSongsByUserId(string userId)
        {
            return _context.PlaylistSongs
                .Include(wb => wb.Song)
                .Include(wb => wb.Playlist)
                .Where(wb => wb.Playlist.IdUser == userId)
                .ToList();
        }
        public PlaylistSong GetPlaylistSongById(int id)
        {
            return _context.PlaylistSongs
                .Include(wb => wb.Song)
                .FirstOrDefault(wb => wb.Id == id);
        }
        public IEnumerable<Playlist> GetPlaylistsByUserId(string userId)
        {
            return _context.Playlists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .Where(p => p.IdUser == userId)
                .ToList();
        }
        public IEnumerable<Playlist> GetByUserId(string userId)
        {
            return _context.Playlists
                .Include(p => p.PlaylistSongs)
                .Where(p => p.IdUser == userId)
                .ToList();
        }

        public void AddPlaylistSong(PlaylistSong playlistSong)
        {
            _context.PlaylistSongs.Add(playlistSong);
        }

        public Playlist GetPlaylistWithSongs(int playlistId)
        {
            return _context.Playlists
                .Include(p => p.PlaylistSongs)
            .ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.SongGenres)
                    .ThenInclude(sg => sg.Genre)
        .Include(p => p.PlaylistSongs)
            .ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.SongArtists)
                    .ThenInclude(sa => sa.Artist)
        .FirstOrDefault(p => p.Id == playlistId);
        }
        public PlaylistSong GetPlaylistSong(int playlistId, int songId)
        {
            return _context.PlaylistSongs
                .FirstOrDefault(ps => ps.IdPlaylist == playlistId && ps.IdSong == songId);
        }
        public void RemovePlaylistSong(PlaylistSong playlistSong)
        {
            _context.PlaylistSongs.Remove(playlistSong);
        }
    }
}
