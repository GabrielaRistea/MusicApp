using Music_App.DTOs;
using Music_App.Models;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;
using NuGet.Protocol.Core.Types;

namespace Music_App.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public IEnumerable<ReviewDto> GetReviewsForSong(int songId)
        {
            return _reviewRepository.GetReviewsBySong(songId)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Comm = r.Comm,
                    Rating = r.Rating,
                    Date = r.Date.ToUniversalTime(),
                    IdUser = r.IdUser,
                    UserName = r.User?.UserName,
                    IdSong = r.IdSong,
                    ProfilPicture = r.User.ProfilPicture
                });
        }
        public void AddReview(ReviewDto reviewDto)
        {
            var review = new Review
            {
                Comm = reviewDto.Comm,
                Rating = reviewDto.Rating,
                Date = DateTime.Now.ToUniversalTime(),
                IdUser = reviewDto.IdUser,
                IdSong = reviewDto.IdSong
            };
            _reviewRepository.Add(review);
            _reviewRepository.Save();
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAll().ToList();
        }
        public async Task<List<ReviewDto>> GetAllReviewsForSongAsync(int songId)
        {
            var reviews = await _reviewRepository.GetAllReviewsForSongAsync(songId);

            return reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Comm = r.Comm,
                Rating = r.Rating,
                Date = r.Date.ToUniversalTime(),
                IdUser = r.IdUser,
                UserName = r.User?.UserName,
                IdSong = r.IdSong,
                ProfilPicture = r.User.ProfilPicture
            }).ToList();
        }
    }
}
