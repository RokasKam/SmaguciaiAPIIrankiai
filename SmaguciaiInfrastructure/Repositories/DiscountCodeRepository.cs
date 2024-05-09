using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class DiscountCodeRepository : IDiscountCodeRepository
{
    private readonly SmaguciaiDataContext _dbContext;
    
    public DiscountCodeRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public DiscountCode GetByCode(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException("Code cannot be null or empty", nameof(code));
        }

        // Query the database for the discount code
        var discountCode = _dbContext.DiscountCodes.FirstOrDefault(dc => dc.Code == code);

        if (discountCode == null)
        {
            throw new KeyNotFoundException($"No discount code found with code: {code}");
        }

        return discountCode;
    }

    public bool DeleteDiscountCode(Guid id)
    {
        try
        {
            var place = _dbContext.DiscountCodes.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.DiscountCodes.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}