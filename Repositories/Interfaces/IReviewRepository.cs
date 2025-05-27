using Music_App.Models;

namespace Music_App.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        Review GetById(int id);
        void Add(Review review);
        void Update(Review review);
        void Delete(Review review);
        void Save();
        IEnumerable<Review> GetReviewsBySong(int songId);
        Task<List<Review>> GetAllReviewsForSongAsync(int songId);
    }
}
