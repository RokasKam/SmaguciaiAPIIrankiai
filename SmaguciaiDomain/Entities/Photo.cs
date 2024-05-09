namespace SmaguciaiDomain.Entities;

public class Photo : BaseEntity
{
    public string URL { get; set; }
    public bool IsMain { get; set; }
    public string AlterText { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}