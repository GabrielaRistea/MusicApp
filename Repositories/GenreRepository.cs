using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private MusicAppContext _context;
        public GenreRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
        public void Create(Genre genre)
        {
            _context.Genres.Add(genre);
        }
        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool GenreExists(int id)
        {
            return _context.Genres.Any(g => g.Id == id);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }
        public Genre GetById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }
    }
}
