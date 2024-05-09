using SmaguciaiCore.Requests;

namespace SmaguciaiAPI.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Order;
using SmaguciaiCore.Requests.Product;


public class OrderProductController : BaseController
{
    private readonly IOrderProductService _orderProductService;
    
    public OrderProductController(IOrderProductService orderProductService)
    {
        _orderProductService = orderProductService;
    }
    [HttpPost]
    public IActionResult AddNewOrder(OrderProductRequest request)
    {
        var res = _orderProductService.AddNewOrderProduct(request);
        return Ok(res);
    }
}