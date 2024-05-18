using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Responses.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public String Nickname { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Email { get; set; }
    public String PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int ReviewCount { get; set; }
    public Role Role { get; set; }
    public Gender Gender { get; set; }
    public String Country { get; set; }
    public String District { get; set; }
    public String City { get; set; }
    public String Street { get; set; }
    public String ZipCode { get; set; }
    public int HouseNumber { get; set; }
    public int? FlatNumber { get; set; }
}
