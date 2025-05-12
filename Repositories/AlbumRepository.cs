using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private MusicAppContext _context;
        public AlbumRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Album> GetAll()
        {
            return _context.Albums
                .Include(a => a.Artist)
                .Include(s => s.Songs);
        }
        public void Create(Album album)
        {
            _context.Albums.Add(album);
        }
        public void Delete(Album album)
        {
            _context.Albums.Remove(album);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool AlbumExists(int id)
        {
            return _context.Albums.Any(a => a.Id == id);
        }

        public void Update(Album album)
        {
            _context.Albums.Update(album);
        }
        public Album GetById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id == id);
        }
        public Album GetByIdWithRelatedEntities(int id)
        {
            return _context.Albums.Include(a => a.Artist)

                .FirstOrDefault(m => m.Id == id);
        }
        public List<Artist> GetAllArtists()
        {
            return _context.Artists.ToList();
        }

        public List<Song> GetAllSongs()
        {
            return _context.Songs.ToList();
        }
        public List<Album> GetAlbumsByArtist(int artistId)
        {
            return _context.Albums
               .Include(a => a.Artist)
               .Include(s => s.Songs)
               .Where(a => a.IdArtist == artistId)
               .ToList();
        }
    }
}
