using System.ComponentModel.DataAnnotations;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Requests.Photo;

public class PhotoRequest
{
    [Required(ErrorMessage = "The URL field cannot be empty")]
    public string URL { get; set; }
    
    [Required(ErrorMessage = "The AlterText field cannot be empty")]
    public string AlterText { get; set; }
    
}