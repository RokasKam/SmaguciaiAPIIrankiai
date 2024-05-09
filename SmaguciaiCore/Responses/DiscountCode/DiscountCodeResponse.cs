namespace SmaguciaiCore.Responses.DiscountCode;

public class DiscountCodeResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Discount { get; set; }
    public DateTime CreationDate { get; set; }
}