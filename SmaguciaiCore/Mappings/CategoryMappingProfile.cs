using AutoMapper;
using SmaguciaiCore.Requests.Category;
using SmaguciaiCore.Responses.Category;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoyResponse>();
        CreateMap<CategoryRequest, Category>();
    }
}