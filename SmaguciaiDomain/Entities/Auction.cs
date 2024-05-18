namespace SmaguciaiDomain.Entities;
public enum AuctionStatus
{
    Ready,
    Ongoing,
    Finished,
    Won
}
public class Auction : Product
{
    public DateTime StartTime{ get; set; }
    public DateTime FinishTime { get; set; }
    public AuctionStatus AuctionStatus { get; set; }
    public ICollection<Bid> Bids { get; set; }


}