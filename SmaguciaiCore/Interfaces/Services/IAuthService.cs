using SmaguciaiCore.Requests.User;
using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Interfaces.Services;

public record HashPasswordResponse(byte[] PasswordHash, byte[] PasswordSalt);

public interface IAuthService
{
    HashPasswordResponse HashPassword(string password);

    UserResponse Login(LoginRequest login);

    Guid Register(RegisterRequest register);
}