using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IUserRepository
{    
    User? GetByEmailOrDefault(string email);
    User PostUser(User user);
    User GetById(Guid id);
    bool EditUser(User user);

    bool DeleteUser(Guid id);
    bool EditPassword(User user);

}