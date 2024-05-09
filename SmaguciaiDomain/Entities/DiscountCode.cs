namespace SmaguciaiDomain.Entities;

public class DiscountCode : BaseEntity
{
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Discount { get; set; }
    public DateTime CreationDate { get; set; }
    public Order Order { get; set; }
}