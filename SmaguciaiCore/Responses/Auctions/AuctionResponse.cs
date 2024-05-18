using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Responses.Auctions;

public class AuctionResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
    public string Color { get; set; }
    public int Amount { get; set; }
    public decimal RatingAverage { get; set; }
    public int RatingAmount { get; set; }
    public string Description { get; set; }
    public int WarrantyPeriod { get; set; }
    public Gender Gender { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public AuctionStatus AuctionStatus { get; set; }
}