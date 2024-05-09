using AutoMapper;
using SmaguciaiCore.Requests.Photo;
using SmaguciaiCore.Responses.Photo;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class PhotoMappingProfile : Profile
{
    public PhotoMappingProfile()
    {
        CreateMap<PhotoRequest, Photo>();
        CreateMap<Photo, PhotoResponse>();
    }
}