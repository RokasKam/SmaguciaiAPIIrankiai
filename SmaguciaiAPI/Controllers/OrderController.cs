using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Order;
using SmaguciaiCore.Requests.Product;

namespace SmaguciaiAPI.Controllers;

public class OrderController : BaseController
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetIdById(Guid id)
    {
        return Ok(_orderService.GetById(id));
    }
    [HttpPost]
    public IActionResult AddNewOrder(OrderRequest request)
    {
        var res = _orderService.AddNewOrder(request);
        return Ok(res);
    }
}