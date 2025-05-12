using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class ArtistRepository : IArtistRepository
    {

        private MusicAppContext _context;
        public ArtistRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists
                .Include(a => a.Albums)
                .Include(s => s.SongArtists);
        }
        public void Create(Artist artist)
        {
            _context.Artists.Add(artist);
        }
        public void Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ArtistExists(int id)
        {
            return _context.Artists.Any(a => a.Id == id);
        }

        public void Update(Artist artist)
        {
            _context.Artists.Update(artist);
        }
        public Artist GetById(int id)
        {
            return _context.Artists.FirstOrDefault(a => a.Id == id);
        }
        public List<Album> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public List<SongArtist> GetAllSongArtists()
        {
            return _context.SongArtists.ToList();
        }
    }
}
