using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Interfaces.Services;

public interface IJwtService
{
    public JwtResponse BuildJwt(UserResponse user);
}