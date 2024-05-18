using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Bid;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class BidService : IBidService
{
    private readonly IBidRepository _bidRepository;
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;

    public BidService(IBidRepository bidRepository, IAuctionRepository auctionRepository, IMapper mapper)
    {
        _bidRepository = bidRepository;
        _auctionRepository = auctionRepository;
        _mapper = mapper;
    }

    public Guid PlaceBid(BidRequest bidRequest)
    {
        var auction = _auctionRepository.GetById(bidRequest.AuctionId);
        if (auction.FinishTime < DateTime.Now)
        {
            throw new Exception("Auction has finished");
        }

        var bids = _bidRepository.GetAllAuctionBid(bidRequest.AuctionId);
        if (bids.Count() != 0)
        {
            var sum = bids.MaxBy(a => a.BidSum)!.BidSum;
            if (sum >= bidRequest.BidSum)
            {
                throw new Exception("Your bidding amount is too low");
            }
        }

        var response = _mapper.Map<Bid>(bidRequest);
        return _bidRepository.PlaceBid(response);
    }
}