using AutoMapper;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Requests.ShippingAddress;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class ShippingAddressMappingProfile: Profile
{
    public ShippingAddressMappingProfile()
    {
        CreateMap<ShippingAddressRequest, ShippingAddress>();
        CreateMap<ShippingAddress, ShippingAddressResponse>();
    }
}