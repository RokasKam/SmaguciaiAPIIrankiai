using SmaguciaiCore.Requests.User;
using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Interfaces.Services;

public interface IUserService
{
    UserResponse GetById(Guid id);
    bool EditUser(Guid id,UserEditRequest request);

    bool DeleteUser(Guid id);
    bool EditPassword(Guid id,PasswordEditRequest request);

}