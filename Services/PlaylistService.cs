using Microsoft.EntityFrameworkCore;
using Music_App.DTOs;
using Music_App.Models;
using Music_App.Repositories;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class PlaylistService : IPlaylistService
    {
        private IPlaylistRepository _playlistRepository;
        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _playlistRepository.GetAll().ToList();
        }
        public void AddPlaylist(Playlist playlist)
        {
            _playlistRepository.Create(playlist);
            _playlistRepository.Save();
        }
        public void UpdatePlaylist(Playlist playlist)
        {
            _playlistRepository.Update(playlist);
            _playlistRepository.Save();
        }
        public void DeletePlaylist(int id)
        {
            var playlist = _playlistRepository.GetById(id);
            if (playlist != null)
            {
                _playlistRepository.Delete(playlist);
                _playlistRepository.Save();
            }
        }
        public bool PlaylistExists(int id)
        {
            return _playlistRepository.PlaylistExists(id);
        }
        public Playlist GetPlaylistById(int id)
        {
            return _playlistRepository.GetById(id);
        }
        public List<Playlist> GetPlaylistsByUser(string userId)
        {
            return _playlistRepository.GetPlaylistsByUserId(userId).ToList();
        }
        public IEnumerable<Playlist> GetByUserId(string userId)
        {
            return _playlistRepository.GetByUserId(userId);
        }
        public async Task<string> AddSongToPlaylistAsync(int playlistId, int songId)
        {
            if (_playlistRepository.PlaylistSongExists(playlistId, songId))
            {
                return "Already added to playlist!";
            }

            var playlistSong = new PlaylistSong
            {
                IdPlaylist = playlistId,
                IdSong = songId
            };

            _playlistRepository.AddPlaylistSong(playlistSong);
            _playlistRepository.Save();

            return "Added to playlist!";
        }
        public async Task<bool> PlaylistSongExistsAsync(int playlistId, int songId)
        {
            return _playlistRepository.PlaylistSongExists(playlistId, songId);
        }

        public PlaylistSong GetPlaylistSongById(int id)
        {
            return _playlistRepository.GetPlaylistSongById(id);
        }
        public PlaylistDto GetPlaylistDetails(int playlistId)
        {
            var playlist = _playlistRepository.GetPlaylistWithSongs(playlistId);

            if (playlist == null)
                return null;

            var dto = new PlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                SongDto = playlist.PlaylistSongs
                    .Select(ps => new SongDTO
                    {
                        Id = ps.Song.Id,
                        Name = ps.Song.Name,
                        Duration = ps.Song.Duration,
                        ReleaseDate = ps.Song.ReleaseDate,
                        Link = ps.Song.Link,
                        IdAlbum = ps.Song.IdAlbum,
                        Artists = ps.Song.SongArtists?.Select(sa => sa.Artist?.Id ?? 0).ToList() ?? [],
                        ArtistNames = ps.Song.SongArtists?.Select(sa => sa.Artist?.Name ?? "").ToList() ?? [],
                        Genres = ps.Song.SongGenres?.Select(sg => sg.Genre?.Id ?? 0).ToList() ?? [],
                        GenreTypes = ps.Song.SongGenres?.Select(sg => sg.Genre?.Type ?? "").ToList() ?? [],
                    }).ToList()
            };

            return dto;
        }

        public async Task<string> RemoveSongFromPlaylistAsync(int playlistId, int songId)
        {
            var playlistSong = _playlistRepository.GetPlaylistSong(playlistId, songId);
            if (playlistSong == null)
            {
                return "Song not found in playlist!";
            }

            _playlistRepository.RemovePlaylistSong(playlistSong);
            _playlistRepository.Save();
            return "Removed from playlist!";
        }

    }
}
