namespace SmaguciaiDomain.Entities;

public class Report : BaseEntity
{
    public string Text { get; set; }
    public DateTime DateAdded { get; set; }
    
    public Guid ReviewId { get; set; }
    public Review Review { get; set; }
    
    public Guid UserID { get; set; }
    public User User { get; set; }
    

}