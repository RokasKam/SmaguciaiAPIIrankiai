namespace SmaguciaiCore.Responses.Order;

public class OrderResponse
{
    public decimal WholePrice { get; set; }
    public decimal WholeAmount { get; set; }
    public Guid UserId { get; set; }
    public Guid? DiscountcodeId { get; set; } = null;
    public Guid ShippingAddressId { get; set; }
}