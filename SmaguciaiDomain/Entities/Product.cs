namespace SmaguciaiDomain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
    public string Color { get; set; }
    public int Amount { get; set; }
    public decimal RatingAverage { get; set; }
    public int RatingAmount { get; set; }
    public string Description { get; set; }
    public Gender Gender { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Photo> Photos { get; set; }
    public ICollection<Review> Review { get; set; }
    public ICollection<OrderPorduct> OrderPorducts { get; set; }
}