using SmaguciaiCore.Requests;

namespace SmaguciaiCore.Interfaces.Services;

public interface IOrderProductService
{
    bool AddNewOrderProduct(OrderProductRequest orderProductRequest);
}