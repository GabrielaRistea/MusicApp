using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface IGenreService
    {
        List<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int id);
        bool GenreExists(int id);
        Genre GetGenreById(int id);
    }
}
