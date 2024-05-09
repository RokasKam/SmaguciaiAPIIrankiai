using System.ComponentModel.DataAnnotations;
namespace SmaguciaiCore.Requests.Report;

public class ReportRequest
{
    [Required(ErrorMessage = "The Text field cannot be empty")]
    public string Text { get; set; }
    [Required(ErrorMessage = "The Id field cannot be empty")]
    public Guid UserId{ get; set; }
    [Required(ErrorMessage = "The Id field cannot be empty")]
    public Guid ReviewId{ get; set; }
}