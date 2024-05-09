namespace SmaguciaiDomain.Entities;

public class Order : BaseEntity
{
    public decimal WholePrice { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal WholeAmount { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Nullable<Guid> DiscountcodeId { get; set; }
    public DiscountCode? DiscountCode { get; set; }
    public Guid ShippingAddressId { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public ICollection<OrderPorduct> OrderPorducts { get; set; }
}