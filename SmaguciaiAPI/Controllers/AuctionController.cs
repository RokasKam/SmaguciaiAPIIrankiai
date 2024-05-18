using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Auction;
using SmaguciaiCore.Requests.Category;

namespace SmaguciaiAPI.Controllers;

public class AuctionController : BaseController
{
    private readonly IAuctionService _auctionService;

    public AuctionController(IAuctionService auctionService)
    {
        _auctionService = auctionService;
    }

    [HttpPost]
    public IActionResult AddNew(AuctionRequest categoryRequest)
    {
        return Ok(_auctionService.AddNew(categoryRequest));
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetAuction(Guid id)
    {
        return Ok(_auctionService.GetById(id));
    }
    [HttpGet]
    public IActionResult GetAuctions()
    {
        return Ok(_auctionService.GetAll());
    }
}