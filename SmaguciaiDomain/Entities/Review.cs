namespace SmaguciaiDomain.Entities;

public class Review : BaseEntity
{
    public string Text { get; set; }
    public DateTime DateAdded { get; set; }
    public decimal Rating { get; set; }
    public bool Reported { get; set; }

    public Guid ProductID { get; set; }
    public Product Product { get; set; }
    
    public Guid UserID { get; set; }
    public User User { get; set; }
    
    public ICollection<Report> Report { get; set; }
}