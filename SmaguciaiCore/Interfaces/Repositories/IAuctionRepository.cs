using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IAuctionRepository
{
    Guid AddNew(Auction auction);
    IEnumerable<Auction> GetAll();
    Auction GetById(Guid id);
    void UpdateFinishDate(Guid id);
    void UpdateStatus(Guid id);
}