namespace SmaguciaiDomain.Entities;

public class Bid : BaseEntity
{
    public double BidSum { get; set; }
    public DateTime Time { get; set; }
    public string CardNumber { get; set; } 
    public string UserName { get; set; }
    public string CVC { get; set; }
    public string ExpDate { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; }
    
}