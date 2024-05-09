namespace SmaguciaiCore.Responses.User;

public class ShippingAddressResponse
{
    public Guid Id { get; set; }
    public String Country { get; set; }
    public String District { get; set; }
    public String City { get; set; }
    public String Street { get; set; }
    public String ZipCode { get; set; }
    public int HouseNumber { get; set; }
    public int? FlatNumber { get; set; }
}