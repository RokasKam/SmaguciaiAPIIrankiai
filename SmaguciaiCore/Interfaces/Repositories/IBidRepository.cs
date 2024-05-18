using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IBidRepository
{
    Guid PlaceBid(Bid bid);
    IEnumerable<Bid> GetAllAuctionBid(Guid auctionId);
}