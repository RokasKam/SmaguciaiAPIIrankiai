using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Report;

namespace SmaguciaiAPI.Controllers;

public class ReportController : BaseController
{
    private readonly IReportService _reportService;
    
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    [HttpPost]
    public IActionResult AddNewReport(ReportRequest request)
    {
        var res = _reportService.AddNewReport(request);
        return Ok(res);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_reportService.GetById(id));
    }
    
    [HttpGet("{reviewId:guid}")]
    public IActionResult GetReportsByReviewId(Guid reviewId)
    {
        var reviews = _reportService.GetReportsByReviewId(reviewId);
        return Ok(reviews);
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReport(Guid id)
    {
        return Ok(_reportService.DeleteReport(id));
    }
}