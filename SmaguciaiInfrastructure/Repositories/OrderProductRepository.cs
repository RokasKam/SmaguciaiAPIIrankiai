using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public OrderProductRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool AddNewOrderProduct(OrderPorduct orderPorduct)
    {
        orderPorduct.Id = Guid.NewGuid();
        _dbContext.OrderPorducts.Add(orderPorduct);
        _dbContext.SaveChanges();
        return true;
    }
}