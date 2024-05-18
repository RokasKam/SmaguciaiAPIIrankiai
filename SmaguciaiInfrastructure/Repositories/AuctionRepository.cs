using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class AuctionRepository : IAuctionRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public AuctionRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid AddNew(Auction auction)
    {
        auction.Id = Guid.NewGuid();
        auction.RatingAmount = 0;
        auction.RatingAverage = 0;
        auction.CreationDate = DateTime.Now;
        _dbContext.Auctions.Add(auction);
        _dbContext.SaveChanges();
        return auction.Id;
    }

    public IEnumerable<Auction> GetAll()
    {
        IQueryable<Auction> entities = _dbContext.Auctions.Where(a=> a.AuctionStatus != AuctionStatus.Won);
        return entities.ToList();
    }

    public Auction GetById(Guid id)
    {
        var product = _dbContext.Auctions.FirstOrDefault(x => x.Id == id);
        return product;
    }

    public void UpdateFinishDate(Guid id)
    {
        var product = _dbContext.Auctions.FirstOrDefault(x => x.Id == id);
        product.FinishTime = product.FinishTime.AddDays(2);
        _dbContext.SaveChanges();

    }

    public void UpdateStatus(Guid id)
    {
        var product = _dbContext.Auctions.FirstOrDefault(x => x.Id == id);
        product.AuctionStatus = AuctionStatus.Won;
        _dbContext.SaveChanges();
    }
}