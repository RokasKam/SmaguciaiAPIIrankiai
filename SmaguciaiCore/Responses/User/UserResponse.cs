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
}
