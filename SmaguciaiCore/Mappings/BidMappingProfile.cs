using AutoMapper;
using SmaguciaiCore.Requests.Bid;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class BidMappingProfile : Profile
{
    public BidMappingProfile()
    {
        CreateMap<BidRequest, Bid>();
    }
}