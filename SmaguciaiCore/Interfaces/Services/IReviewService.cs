using SmaguciaiCore.Requests.Review;
using SmaguciaiCore.Responses.Review;

namespace SmaguciaiCore.Interfaces.Services;

public interface IReviewService
{
    bool AddNewReview(ReviewRequest request);
    ReviewResponse GetById(Guid id);
    bool EditReview(Guid id, ReviewRequest request);
    List<ReviewResponse> GetReviewsByProductId(Guid productId);
    List<ReviewResponse> GetReportedReviews();
    bool DeleteReview(Guid id);
}