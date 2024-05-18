namespace SmaguciaiCore.Requests.Bid;

public class BidRequest
{
    public double BidSum { get; set; }
    public string CardNumber { get; set; } 
    public string UserName { get; set; }
    public string CVC { get; set; }
    public string ExpDate { get; set; }
    public Guid UserId { get; set; }
    public Guid AuctionId { get; set; }
}