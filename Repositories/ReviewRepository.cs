using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private MusicAppContext _context;
        public ReviewRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Song);
        }
        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }
        public void Add(Review review)
        {
            _context.Reviews.Add(review);
        }
        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Review> GetReviewsBySong(int songId)
        {
            return _context.Reviews
                .Include(r => r.User)
                .Where(r => r.IdSong == songId);
        }
        public async Task<List<Review>> GetAllReviewsForSongAsync(int songId)
        {
            return await _context.Reviews
                .Where(r => r.IdSong == songId)
                .Include(r => r.User) 
                .ToListAsync();
        }
    }
}
