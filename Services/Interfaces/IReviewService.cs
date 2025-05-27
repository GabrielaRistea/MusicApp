using Music_App.DTOs;
using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDto> GetReviewsForSong(int songId);
        void AddReview(ReviewDto reviewDto);
        IEnumerable<Review> GetAllReviews();
        Task<List<ReviewDto>> GetAllReviewsForSongAsync(int songId);
    }
}
