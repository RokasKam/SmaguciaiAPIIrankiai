using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ShippingAddressRepository : IShippingAddressRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public ShippingAddressRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool AddNewShippingAddress(ShippingAddress shippingAddress)
    {
        try
        {
            shippingAddress.Id = Guid.NewGuid();
            _dbContext.ShippingAddresses.Add(shippingAddress);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public ShippingAddress GetByUserId(Guid id)
    {
        var shippingAddress = _dbContext.ShippingAddresses.FirstOrDefault(u => u.UserId == id);
        return shippingAddress;    
    }
    public ShippingAddress GetById(Guid id)
    {
        var shippingAddress = _dbContext.ShippingAddresses.FirstOrDefault(u => u.Id == id);
        return shippingAddress;    
    }
    
    public bool EditShippingAddress(ShippingAddress shippingAddress)
    {
        var local = _dbContext.ShippingAddresses.Local.FirstOrDefault(oldEntity => oldEntity.Id == shippingAddress.Id);
        if (local != null)
        {
            _dbContext.Entry(local).State = EntityState.Detached;
        }

        _dbContext.Entry(shippingAddress).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return true;
    }

    public bool DeleteShippingAddress(Guid id)
    {
        try
        {
            var place = _dbContext.ShippingAddresses.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.ShippingAddresses.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}