using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Review;
using SmaguciaiCore.Responses.Review;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IUserRepository userRepository, IProductRepository productRepository)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }
    
    public bool AddNewReview(ReviewRequest request)
    {
        var review = _mapper.Map<Review>(request);
        var user = _userRepository.GetById(request.UserId);
        var product = _productRepository.GetById(request.ProductId);
        var res = _reviewRepository.AddNewReview(user, review, product);
        return res;
    }

    public ReviewResponse GetById(Guid id)
    {
        var review = _reviewRepository.GetById(id);
        var response = _mapper.Map<ReviewResponse>(review);
        return response;
    }

    public bool EditReview(Guid id, ReviewRequest request)
    {
        try
        {
            var oldReview = _reviewRepository.GetById(id);
            if (oldReview is null)
            {
                throw new Exception("Review with provided id does not exist");
            }

            var newReview = _mapper.Map<Review>(request);
            newReview.Id = id;
            var product = _productRepository.GetById(request.ProductId);

            var res = _reviewRepository.EditReview(oldReview, newReview, product);
            return true;
        }
        catch
        {
            return false;
        }
    }

    
    public List<ReviewResponse> GetReviewsByProductId(Guid productId)
    {
        var reviews = _reviewRepository.GetReviewsByProductId(productId);
        return _mapper.Map<List<ReviewResponse>>(reviews);
    }
    
    public List<ReviewResponse> GetReportedReviews()
    {
        var reportedReviews = _reviewRepository.GetReportedReviews();
        return _mapper.Map<List<ReviewResponse>>(reportedReviews);
    }
    
    public bool DeleteReview(Guid id)
    {
        try
        {
            var reviewToDelete = _reviewRepository.GetById(id);
            if (reviewToDelete == null)
            {
                throw new Exception("Review not found");
            }

            var product = _productRepository.GetById(reviewToDelete.ProductID);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return _reviewRepository.DeleteReview(reviewToDelete, product);
        }
        catch
        {
            return false;
        }
    }


}