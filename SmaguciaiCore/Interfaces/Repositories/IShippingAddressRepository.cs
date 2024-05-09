using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IShippingAddressRepository
{
    bool AddNewShippingAddress(ShippingAddress shippingAddress);
    ShippingAddress GetById(Guid id);
    ShippingAddress GetByUserId(Guid id);
    
    bool EditShippingAddress(ShippingAddress shippingAddress);

    bool DeleteShippingAddress(Guid id);
}