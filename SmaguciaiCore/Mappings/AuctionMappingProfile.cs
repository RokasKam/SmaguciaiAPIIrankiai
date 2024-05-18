using AutoMapper;
using SmaguciaiCore.Requests.Auction;
using SmaguciaiCore.Responses.Auctions;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class AuctionMappingProfile : Profile
{
    public AuctionMappingProfile()
    {
        CreateMap<AuctionRequest, Auction>();
        CreateMap<Auction, AuctionResponse>();
    }
}