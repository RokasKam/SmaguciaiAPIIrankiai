namespace SmaguciaiDomain.Entities;
public enum Role
{
    Admin,
    User
}
public enum Gender
{
    Man,
    Women,
    Unisex
}

public class User : BaseEntity
{
    public String Nickname { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public String PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int ReviewCount { get; set; }
    public Role Role { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Review> Review { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public ICollection<Order> Order { get; set; }
    public ICollection<Report> Report { get; set; }
}