using Music_App.DTOs;

namespace Music_App.ViewModel
{
    public class ReviewViewModel
    {
        public int SongId { get; set; } 
        public List<ReviewDto> Reviews { get; set; } 
        public ReviewDto NewReview { get; set; }
        //public List<ReviewDto> ExistingReviews { get; set; }
    }
}
