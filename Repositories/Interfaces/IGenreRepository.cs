using Music_App.Models;

namespace Music_App.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        bool GenreExists(int id);
        void Create(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        void Save();
        Genre GetById(int id);
    }
}
