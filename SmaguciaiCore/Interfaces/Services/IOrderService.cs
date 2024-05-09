using SmaguciaiCore.Requests.Order;
using SmaguciaiCore.Responses.Order;

namespace SmaguciaiCore.Interfaces.Services;

public interface IOrderService
{
    Guid AddNewOrder(OrderRequest orderRequest);
    OrderResponse GetById(Guid id);

}