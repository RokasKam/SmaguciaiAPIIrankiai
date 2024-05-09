using AutoMapper;
using SmaguciaiCore.Requests;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class OrderProductMappingProfile: Profile
{
    public OrderProductMappingProfile()
    {
        CreateMap<OrderProductRequest, OrderPorduct>();
    }
}