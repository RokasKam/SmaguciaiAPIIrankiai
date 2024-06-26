namespace SmaguciaiDomain.Entities;

public class Order : BaseEntity
{
    public decimal WholePrice { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal WholeAmount { get; set; }
    public int? RouteIndex { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Nullable<Guid> DiscountcodeId { get; set; }
    public DiscountCode? DiscountCode { get; set; }
    public ICollection<OrderPorduct> OrderPorducts { get; set; }
    public Nullable<Guid> RouteId { get; set; }
    public Route? Route { get; set; }
}