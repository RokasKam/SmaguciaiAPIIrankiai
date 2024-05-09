using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public UserRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User? GetByEmailOrDefault(string email)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User PostUser(User user)
    {
        user.Id = Guid.NewGuid();
        user.ReviewCount = 0;
        _dbContext.Users.Add(user); 
        _dbContext.SaveChanges();
        return user;
    }

    public User GetById(Guid id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        return user;    
    }
    
    public bool EditUser(User user)
    {
        try
        {
            var local = _dbContext.Users.Local.FirstOrDefault(oldEntity => oldEntity.Id == user.Id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            user.PasswordHash = local.PasswordHash;
            user.PasswordSalt = local.PasswordSalt;
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteUser(Guid id)
    {
        try
        {
            var place = _dbContext.Users.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.Users.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool EditPassword(User user)
    {
        try
        {
            var local = _dbContext.Users.Local.FirstOrDefault(oldEntity => oldEntity.Id == user.Id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}