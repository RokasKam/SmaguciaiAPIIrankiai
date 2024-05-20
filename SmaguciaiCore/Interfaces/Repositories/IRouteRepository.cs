using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IRouteRepository
{
    Guid CreateNewRoute(Route route);
    Route GetRouteByDate(DateTime dateTime);
}