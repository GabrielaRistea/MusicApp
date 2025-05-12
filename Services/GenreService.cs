using Music_App.Models;
using Music_App.Repositories;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class GenreService : IGenreService
    { 
        private IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll().ToList();
        }
        public void AddGenre(Genre genre)
        {
            _genreRepository.Create(genre);
            _genreRepository.Save();
        }
        public void UpdateGenre(Genre genre)
        {
            _genreRepository.Update(genre);
            _genreRepository.Save();
        }
        public void DeleteGenre(int id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre != null)
            {
                _genreRepository.Delete(genre);
                _genreRepository.Save();
            }
        }
        public bool GenreExists(int id)
        {
            return _genreRepository.GenreExists(id);
        }
        public Genre GetGenreById(int id)
        {
            return _genreRepository.GetById(id);
        }
    }
}
