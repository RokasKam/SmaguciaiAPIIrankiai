using AutoMapper;
using SmaguciaiCore.Requests.Order;
using SmaguciaiCore.Responses.Order;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderRequest, Order>();
        CreateMap<Order, OrderResponse>();
    }
}