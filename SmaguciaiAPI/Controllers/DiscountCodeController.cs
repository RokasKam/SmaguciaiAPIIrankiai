using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;

namespace SmaguciaiAPI.Controllers;

public class DiscountCodeController : BaseController
{
    private readonly IDiscountCodeService _discountCodeService;
    
    public DiscountCodeController(IDiscountCodeService discountCodeService)
    {
        _discountCodeService = discountCodeService;
    }
    
    [HttpGet("{code}")]
    public IActionResult GetByCode(string code)
    {
        return Ok(_discountCodeService.GetByCode(code));
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReview(Guid id)
    {
        return Ok(_discountCodeService.DeleteDiscountCode(id));
    }
}