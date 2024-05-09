using AutoMapper;
using SmaguciaiCore.Responses.Category;
using SmaguciaiCore.Responses.DiscountCode;
using SmaguciaiDomain.Entities;
namespace SmaguciaiCore.Mappings;

public class DiscountCodeMappingProfile : Profile
{
    public DiscountCodeMappingProfile()
    {
        CreateMap<DiscountCode, DiscountCodeResponse>();
    }
}