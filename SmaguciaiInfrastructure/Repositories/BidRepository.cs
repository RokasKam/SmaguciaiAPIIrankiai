using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class BidRepository : IBidRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public BidRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid PlaceBid(Bid bid)
    {
        bid.Id = Guid.NewGuid();
        bid.Time = DateTime.Now;
        _dbContext.Bids.Add(bid);
        _dbContext.SaveChanges();
        return bid.Id;
    }

    public IEnumerable<Bid> GetAllAuctionBid(Guid auctionId)
    {
        var entities = _dbContext.Bids.Where(e=> e.AuctionId == auctionId);
        return entities.ToList();
    }
}