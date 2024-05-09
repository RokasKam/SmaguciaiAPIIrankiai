namespace SmaguciaiCore.Requests;

public class OrderProductRequest
{
    public int Amount { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
}