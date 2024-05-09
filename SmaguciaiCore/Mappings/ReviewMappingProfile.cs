using AutoMapper;
using SmaguciaiCore.Requests.Review;
using SmaguciaiCore.Responses.Review;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<ReviewRequest, Review>();
        CreateMap<Review, ReviewResponse>();
    }
}