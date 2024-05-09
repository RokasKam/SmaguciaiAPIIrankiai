using System.ComponentModel.DataAnnotations;
using SmaguciaiDomain.Entities;
namespace SmaguciaiCore.Requests.Review;

public class ReviewRequest
{
    [Required(ErrorMessage = "The Text field cannot be empty")]
    public string Text { get; set; }
    [Required(ErrorMessage = "The Rating field cannot be empty")]
    public decimal Rating { get; set; }
    [Required(ErrorMessage = "The Id field cannot be empty")]
    public Guid UserId{ get; set; }
    [Required(ErrorMessage = "The Id field cannot be empty")]
    public Guid ProductId{ get; set; }
}