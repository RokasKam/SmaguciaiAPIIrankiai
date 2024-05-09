using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;

namespace SmaguciaiAPI.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetItem(Guid id)
    {
        return Ok(_productService.GetById(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewItem(ProductRequest request)
    {
        var res = await _productService.AddNewProduct(request);
        return Ok(res);
    }
    [HttpPut("{id:guid}")]
    public IActionResult EditItem(Guid id, ProductRequest request)
    {
        var res = _productService.EditProduct(id,request);
        return Ok(res);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        return Ok(_productService.DeleteProduct(id));
    }
    [HttpGet]
    public IActionResult GetItems([FromQuery] ProductParameters placesParameters)
    {
        return Ok(_productService.GetAll(placesParameters));
    }
}