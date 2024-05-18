using SmaguciaiCore.Requests.Bid;

namespace SmaguciaiCore.Interfaces.Services;

public interface IBidService
{
    Guid PlaceBid(BidRequest bidRequest);
}