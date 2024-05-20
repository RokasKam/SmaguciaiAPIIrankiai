using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public OrderRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Order GetById(Guid id)
    {
        var order = _dbContext.Orders.FirstOrDefault(x => x.Id == id);

        return order;
    }

    public bool UpdatePayment(Guid guid)
    {
        try
        {
            var local = _dbContext.Orders.Local.FirstOrDefault(oldEntity => oldEntity.Id == guid);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            local.IsPaid = true;
            _dbContext.Entry(local).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<Order> GetAllPaidOrdersWithUsers()
    {
        var orders = _dbContext.Orders.Include(o => o.User).Where(o => o.IsPaid && o.RouteIndex == null);
        return orders.ToList();
    }

    public void UpdateRoute(Guid orderId, Guid routeId, int routeIndex)
    {
        var local = _dbContext.Orders.Local.FirstOrDefault(oldEntity => oldEntity.Id == orderId);
        local.RouteId = routeId;
        local.RouteIndex = routeIndex;
        _dbContext.SaveChanges();
    }

    public Guid AddNewOrder(Order order)
    {
        order.Id = Guid.NewGuid();
        order.IsPaid = false;
        order.CreationDate = DateTime.Now;
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order.Id;
    }
}