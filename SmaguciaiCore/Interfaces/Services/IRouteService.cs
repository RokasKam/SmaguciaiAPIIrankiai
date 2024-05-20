using SmaguciaiCore.Responses.Order;
using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Interfaces.Services;

public interface IRouteService
{
    Task GenerateRoute();
    IEnumerable<Tuple<UserResponse, OrderResponse>> GetRoute();
}