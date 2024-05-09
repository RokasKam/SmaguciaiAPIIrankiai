using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Review;

namespace SmaguciaiAPI.Controllers;

public class ReviewController : BaseController
{
    private readonly IReviewService _reviewService;
    
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    [HttpPost]
    public IActionResult AddNewReview(ReviewRequest request)
    {
        
        var res = _reviewService.AddNewReview(request);
        return Ok(res);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_reviewService.GetById(id));
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult EditReview(Guid id, ReviewRequest request)
    {
        var res = _reviewService.EditReview(id,request);
        return Ok(res);
    }
    
    [HttpGet("{productId:guid}")]
    public IActionResult GetReviewsByProductId(Guid productId)
    {
        var reviews = _reviewService.GetReviewsByProductId(productId);
        return Ok(reviews);
    }
    
    [HttpGet]
    public IActionResult GetReportedReviews()
    {
        var reportedReviews = _reviewService.GetReportedReviews();
        return Ok(reportedReviews);
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReview(Guid id)
    {
        return Ok(_reviewService.DeleteReview(id));
    }
}