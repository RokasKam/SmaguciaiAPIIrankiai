using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class RoutRepository : IRouteRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public RoutRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid CreateNewRoute(Route route)
    {
        route.Id = Guid.NewGuid();
        route.RouteDate = DateTime.Today;
        _dbContext.Routes.Add(route);
        _dbContext.SaveChanges();
        return route.Id;
    }

    public Route GetRouteByDate(DateTime dateTime)
    {
       return _dbContext.Routes.Include(r=>r.Orders)
           .ThenInclude(o=>o.User).First(r => r.RouteDate == dateTime);
    }
}