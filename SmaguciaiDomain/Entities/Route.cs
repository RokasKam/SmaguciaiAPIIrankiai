namespace SmaguciaiDomain.Entities;

public class Route : BaseEntity
{
    public DateTime RouteDate { get; set; }
    public int TimeInSeconds { get; set; }
    public ICollection<Order> Orders { get; set; }
}