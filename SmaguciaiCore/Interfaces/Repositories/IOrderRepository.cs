using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IOrderRepository
{
    Guid AddNewOrder (Order order);
    Order GetById(Guid id);
    bool UpdatePayment(Guid guid);
    IEnumerable<Order> GetAllPaidOrdersWithUsers();
    void UpdateRoute(Guid orderId, Guid routeId, int routeIndex);
    IEnumerable<Order> GetOrdersByUser(Guid userId);
}