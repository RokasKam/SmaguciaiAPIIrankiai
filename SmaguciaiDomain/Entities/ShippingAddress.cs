namespace SmaguciaiDomain.Entities;

public class ShippingAddress : BaseEntity
{
    public String Country { get; set; }
    public String District { get; set; }
    public String City { get; set; }
    public String Street { get; set; }
    public String ZipCode { get; set; }
    public int HouseNumber { get; set; }
    public int? FlatNumber { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<Order> Order { get; set; }
}