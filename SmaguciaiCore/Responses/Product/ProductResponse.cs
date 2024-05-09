using SmaguciaiCore.Responses.Photo;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Responses.Product;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
    public string Color { get; set; }
    public int Amount { get; set; }
    public decimal RatingAverage { get; set; }
    public int RatingAmount { get; set; }
    public string Description { get; set; }
    public int WarrantyPeriod { get; set; }
    public Gender Gender { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
    public IEnumerable<PhotoResponse> Photos { get; set; }
}