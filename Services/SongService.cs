
using Music_App.Repositories.Interfaces;
using Music_App.Repositories;
using Music_App.Models;
using Music_App.Services.Interfaces;

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

        public void UpdateSong(Song song)
        {
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
    }
}
