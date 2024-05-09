using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.ShippingAddress;

namespace SmaguciaiAPI.Controllers;

public class ShippingAddressController : BaseController
{
    private readonly IShippingAddressService _shippingAddressService;
    
    public ShippingAddressController(IShippingAddressService shippingAddressService)
    {
        _shippingAddressService = shippingAddressService;
    }
    [HttpPost]
    public IActionResult AddNewShippingAddress(ShippingAddressRequest request)
    {
        var res = _shippingAddressService.AddNewShippingAddress(request);
        return Ok(res);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var shippingAddress = _shippingAddressService.GetById(id);
        return Ok(shippingAddress);
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult EditShippingAddress(Guid id, ShippingAddressRequest request)
    {
        var res = _shippingAddressService.EditShippingAddress(id,request);
        return Ok(res);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteShippingAddress(Guid id)
    {
        return Ok(_shippingAddressService.DeleteShippingAddress(id));
    }
}