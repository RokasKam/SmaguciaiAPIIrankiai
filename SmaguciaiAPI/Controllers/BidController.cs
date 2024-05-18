using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Auction;
using SmaguciaiCore.Requests.Bid;

namespace SmaguciaiAPI.Controllers;

public class BidController : BaseController
{
    private readonly IBidService _bidService;

    public BidController(IBidService bidService)
    {
        _bidService = bidService;
    }

    [HttpPost]
    public IActionResult AddNew(BidRequest bidRequest)
    {
        return Ok(_bidService.PlaceBid(bidRequest));
    }
}