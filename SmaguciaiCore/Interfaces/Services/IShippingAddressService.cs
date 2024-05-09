using SmaguciaiCore.Requests.ShippingAddress;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IShippingAddressService
{
    bool AddNewShippingAddress(ShippingAddressRequest request);
    ShippingAddressResponse GetById(Guid id);
    
    bool EditShippingAddress(Guid id,ShippingAddressRequest request);

    bool DeleteShippingAddress(Guid id);
}