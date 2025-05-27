
using Music_App.Repositories.Interfaces;
using Music_App.Repositories;
using Music_App.Models;
using Music_App.Services.Interfaces;
using Music_App.DTOs;
using static System.Reflection.Metadata.BlobBuilder;
using Humanizer.Localisation;

namespace Music_App.Services
{
    public class SongService : ISongService
    {
        private ISongRepository _songRepository;
        public SongService(ISongRepository songRepository) 
        {
            _songRepository = songRepository;
        }

        public Song GetSongById(int id)
        {
            return _songRepository.GetById(id);
        }

        public void AddSong(Song song)
        {
            _songRepository.Create(song);
            _songRepository.Save();
        }

        public void UpdateSong(SongDTO songDto)
        {
            var song = _songRepository.GetById(songDto.Id);
            mapSong(songDto, song);
            _songRepository.Update(song);
            _songRepository.Save();
        }

        public void DeleteSong(int id)
        {
            var song = _songRepository.GetById(id);
            if (song != null)
            {
                _songRepository.Delete(song);
                _songRepository.Save();
            }
        }

        public Song GetSongAndRelatedById(int id)
        {
            return _songRepository.GetByIdWithRelatedEntities(id);
        }

        public List<Song> GetAllSongs()
        {
            return _songRepository.GetAll().ToList();
        }

        public List<SongArtist> GetAllSongArtists()
        {
            return _songRepository.GetAllSongArtists().ToList();
        }

        public List<SongGenre> GetAllSongGenres()
        {
            return _songRepository.GetAllSongGenres().ToList();
        }

        public List<Album> GetAllAlbums()
        {
            return _songRepository.GetAllAlbums().ToList();
        }

        public List<PlaylistSong> GetAllPlaylistSongs()
        {
            return _songRepository.GetAllPlaylistSongs().ToList();
        }

        public List<Review> GetAllReviews()
        {
            return _songRepository.GetAllReviews().ToList();
        }

        public bool SongExists(int id)
        {
            return _songRepository.SongExists(id);
        }
        public List<Song> GetAllSongsByAlbum(int albumId)
        {
            return _songRepository.GetSongByAlbum(albumId).ToList();
        }

        public GenreDto GetAllSongsGroupedByGenre(int genreId)
        {
            var genres = _songRepository.GetSongByGenre(genreId);
            if (genres == null) return null;
            var songs = genres.SongGenres?
                    .Where(sg => sg.Song != null)
                    .Select(sg => new SongDTO
                    {
                        Id = sg.Song.Id,
                        IdAlbum = sg.Song.IdAlbum,
                        Name = sg.Song.Name,
                        Duration = sg.Song.Duration,
                        ReleaseDate = sg.Song.ReleaseDate.ToUniversalTime(),
                        Link = sg.Song.Link,
                        Artists = sg.Song.SongArtists?.Select(sa => sa.Artist?.Id ?? 0).ToList() ?? [],
                        ArtistNames = sg.Song.SongArtists?.Select(sa => sa.Artist?.Name ?? "").ToList() ?? [],
                        Genres = sg.Song.SongGenres?.Select(sg => sg.Genre?.Id ?? 0).ToList() ?? [],
                        GenreTypes = sg.Song.SongGenres?.Select(sg => sg.Genre?.Type ?? "").ToList() ?? [],
                    }).ToList() ?? new List<SongDTO>();
            return new GenreDto
            {
                Id = genres.Id,
                Type = genres.Type,
                Songs = songs,
                SongTitle = songs.Select(b => b.Name).ToList(),
            };
        }


        private void mapSong(SongDTO dto, Song song)
        {
            song.IdAlbum = dto.IdAlbum;
            song.Name = dto.Name;
            song.Duration = dto.Duration;
            song.Link = dto.Link;
            song.ReleaseDate = dto.ReleaseDate.ToUniversalTime();
            song.SongArtists = dto.Artists.Select(a => new SongArtist() { IdArtist = a }).ToList();
            song.SongGenres = dto.Genres.Select(g => new SongGenre() { IdGenre = g }).ToList();
        }
    }
}
