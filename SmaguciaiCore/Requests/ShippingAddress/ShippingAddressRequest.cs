using System.ComponentModel.DataAnnotations;

namespace SmaguciaiCore.Requests.ShippingAddress;

public class ShippingAddressRequest
{
    [Required(ErrorMessage = "The Country field cannot be empty")]
    public String Country { get; set; }
    [Required(ErrorMessage = "The District field cannot be empty")]
    public String District { get; set; }
    [Required(ErrorMessage = "The City field cannot be empty")]
    public String City { get; set; }
    [Required(ErrorMessage = "The Street field cannot be empty")]
    public String Street { get; set; }
    [Required(ErrorMessage = "The ZipCode field cannot be empty")]
    public String ZipCode { get; set; }
    [Required(ErrorMessage = "The HouseNumber field cannot be empty")]
    public int HouseNumber { get; set; }
    public int? FlatNumber { get; set; }
    [Required(ErrorMessage = "The UserId field cannot be empty")]
    public Guid UserId { get; set; }
}