using SmaguciaiCore.Responses.Category;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IReviewRepository
{
    bool AddNewReview(User user, Review review, Product product);
    Review GetById(Guid id);
    bool EditReview(Review oldReview, Review newReview, Product product);
    List<Review> GetReviewsByProductId(Guid productId);
    List<Review> GetReportedReviews();
    bool DeleteReview(Review review, Product product);
}