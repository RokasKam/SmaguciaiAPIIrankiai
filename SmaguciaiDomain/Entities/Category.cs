namespace SmaguciaiDomain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public int AmountOfProducts { get; set; }
    public ICollection<Product> Product { get; set; }
}