using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music_App.DTOs;
using Music_App.Models;
using Music_App.Services.Interfaces;
using Music_App.ViewModel;
using System.Security.Claims;

namespace Music_App.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int songId)
        {
            var reviewDtos = await _reviewService.GetAllReviewsForSongAsync(songId);

            var viewModel = new ReviewViewModel
            {
                SongId = songId,
                Reviews = reviewDtos,
                NewReview = new ReviewDto { IdSong = songId },
               // ExistingReviews = reviewDtos
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddReview(int songId)
        {
            var reviewDto = new ReviewDto { IdSong = songId };
            return View(reviewDto);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview(ReviewDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            dto.IdUser = userId;
            _reviewService.AddReview(dto);
            TempData["Message"] = "Review added successfully!";
            return RedirectToAction("Index", new { songId = dto.IdSong });
        }
    }
}
