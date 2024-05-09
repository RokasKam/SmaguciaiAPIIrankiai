using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IOrderProductRepository
{
    bool AddNewOrderProduct(OrderPorduct orderPorduct);
}