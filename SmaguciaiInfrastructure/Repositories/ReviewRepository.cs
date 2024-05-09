using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly SmaguciaiDataContext _dbContext;
    private readonly IDiscountCodeEmailService _discountCodeEmailService;
    
    public ReviewRepository(SmaguciaiDataContext dbContext, IDiscountCodeEmailService discountCodeEmailService)
    {
        _dbContext = dbContext;
        _discountCodeEmailService = discountCodeEmailService;
    }
    
    public bool AddNewReview(User user, Review review, Product product)
    {
            review.Id = Guid.NewGuid();
            review.DateAdded = DateTime.Now;
            review.Reported = false;
            _dbContext.Review.Add(review);
            _dbContext.SaveChanges();
            var local = _dbContext.Users.Local.FirstOrDefault(oldEntity => oldEntity.Id == user.Id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            
            var localP = _dbContext.Products.Local.FirstOrDefault(oldEntity => oldEntity.Id == product.Id);
            if (localP != null)
            {
                _dbContext.Entry(localP).State = EntityState.Detached;
            }

            product.RatingAmount++;
            decimal average = (product.RatingAverage * (product.RatingAmount-1) + review.Rating) / product.RatingAmount;
            product.RatingAverage = average;
            
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();

            user.ReviewCount++;
            if (user.ReviewCount >= 10)
            {
                DiscountCode discountCode = new DiscountCode();
                discountCode.Id = Guid.NewGuid();
                discountCode.CreationDate = DateTime.Now;
                discountCode.ExpirationDate = discountCode.CreationDate.AddMonths(1);
                discountCode.Discount = 15;
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                discountCode.Code = new string(Enumerable.Repeat(chars, 7)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                _dbContext.DiscountCodes.Add(discountCode);
                _dbContext.SaveChanges();
                
                if (!_discountCodeEmailService.EmailSendingFunction(user.Email, discountCode.Code, discountCode.ExpirationDate))
                { 
                    throw new Exception("Email error");
                }
                
                user.ReviewCount = 0;
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
    }

    public Review GetById(Guid id)
    {
        var review = _dbContext.Review.FirstOrDefault(u => u.Id == id);
        return review;  
    }
    
    public bool EditReview(Review oldReview, Review newReview, Product product)
    {
        try
        {
            decimal oldTotalRating = product.RatingAverage * product.RatingAmount;
            decimal newTotalRating = oldTotalRating - oldReview.Rating + newReview.Rating;
            product.RatingAverage = newTotalRating / product.RatingAmount;
            newReview.DateAdded = oldReview.DateAdded;
            _dbContext.Entry(oldReview).CurrentValues.SetValues(newReview);
            _dbContext.SaveChanges();
            
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    
    public List<Review> GetReviewsByProductId(Guid productId)
    {
        return _dbContext.Review
            .Where(r => r.ProductID == productId)
            .ToList();
    }
    
    public List<Review> GetReportedReviews()
    {
        return _dbContext.Review
            .Where(r => r.Reported == true)
            .ToList();
    }
    
    public bool DeleteReview(Review review, Product product)
    {
        try
        {
            decimal oldRating = review.Rating;
            _dbContext.Review.Remove(review);
            
            product.RatingAmount--;
            if (product.RatingAmount > 0)
            {
                decimal average = (product.RatingAverage * (product.RatingAmount + 1) - oldRating) /
                                  product.RatingAmount;
                product.RatingAverage = average;
            }
            else
            {
                product.RatingAmount = 0;
                product.RatingAverage = 0;
            }

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

}