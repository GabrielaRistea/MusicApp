using Music_App.Models;
using Music_App.Repositories.Interfaces;
using Music_App.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Linq;

namespace Music_App.Repositories
{
    public class SongRepository : ISongRepository
    {
        private MusicAppContext _context;
        public SongRepository(MusicAppContext musicContext) 
        {
            _context = musicContext;
        }

        public void Create(Song song)
        {
            _context.Songs.Add(song);
        }

        public void Delete(Song song)
        {
            _context.Songs.Remove(song);
        }

        public Song GetByIdWithRelatedEntities(int id)
        {
            return _context.Songs.Include(a => a.Album)
               
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Song> GetAll()
        {
            return _context.Songs
                .Include(s => s.SongArtists)
                .ThenInclude(sa => sa.Artist)
                .Include(s => s.SongGenres)
                .ThenInclude(sg => sg.Genre)
                .Include(s => s.Album)
                .Include(s => s.PlaylistSongs)
                .Include(s => s.Reviews);
        }

        public List<SongArtist> GetAllSongArtists()
        {
            return _context.SongArtists.ToList();
        }

        public List<SongGenre> GetAllSongGenres()
        {
            return _context.SongGenres.ToList();
        }

        public List<Album> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public List<PlaylistSong> GetAllPlaylistSongs()
        {
            return _context.PlaylistSongs.ToList();
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public Song GetById(int id)
        {
            return _context.Songs
                .Include(s => s.SongArtists)
                .ThenInclude(sa => sa.Artist)
                .Include(s => s.SongGenres)
                .ThenInclude(sg => sg.Genre)
                .Include(s => s.Album)
                .Include(s => s.PlaylistSongs)
                .Include(s => s.Reviews).FirstOrDefault(m => m.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool SongExists(int id)
        {
            return _context.Songs.Any(o => o.Id == id);
        }

        public void Update(Song song)
        {
            _context.Songs.Update(song);
        }
        public List<Song> GetSongByAlbum(int albumId)
        {
            return _context.Songs
                .Include(s => s.SongArtists)
                .ThenInclude(sa => sa.Artist)
                .Include(s => s.SongGenres)
                .ThenInclude(sg => sg.Genre)
                .Include(s => s.Album)
                .Include(s => s.PlaylistSongs)
                .Include(s => s.Reviews)
                .Where(a => a.IdAlbum == albumId)
                .ToList();
        }

        public Genre GetSongByGenre(int genreId)
        {
            return _context.Genres
                .Include(a => a.SongGenres)
                .ThenInclude(ab => ab.Song)
                .ThenInclude(ab => ab.SongArtists)
                .ThenInclude(ab => ab.Artist)
                .FirstOrDefault(a => a.Id == genreId);
        }

        public List<Genre> GetAllGenresWithSongs()
        {
            return _context.Genres
                .Include(g => g.SongGenres)
                    .ThenInclude(sg => sg.Song)
                        .ThenInclude(s => s.SongArtists)
                            .ThenInclude(sa => sa.Artist)
                .Include(g => g.SongGenres)
                    .ThenInclude(sg => sg.Song)
                        .ThenInclude(s => s.SongGenres)
                            .ThenInclude(sg => sg.Genre)
                .ToList();
        }

    }
}
