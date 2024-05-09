using System.ComponentModel.DataAnnotations;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Requests.User;

public class PasswordEditRequest
{
    [Required(ErrorMessage = "The OldPassword field cannot be empty")]
    public string OldPassword { get; set; }
    [Required(ErrorMessage = "The NewPassword field cannot be empty")]
    public string Password { get; set; }
}