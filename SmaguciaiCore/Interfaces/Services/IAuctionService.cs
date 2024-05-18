using SmaguciaiCore.Requests.Auction;
using SmaguciaiCore.Requests.Category;
using SmaguciaiCore.Responses.Auctions;
using SmaguciaiCore.Services;

namespace SmaguciaiCore.Interfaces.Services;

public interface IAuctionService
{
    Guid AddNew(AuctionRequest auctionRequest);
    AuctionResponse GetById(Guid id);
    List<AuctionResponse> GetAll();
    Task<bool> ChooseWinner();
}