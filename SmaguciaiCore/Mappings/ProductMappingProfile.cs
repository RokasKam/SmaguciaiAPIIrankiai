using AutoMapper;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Requests.User;
using SmaguciaiCore.Responses.Product;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}