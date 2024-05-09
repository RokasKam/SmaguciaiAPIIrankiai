using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Photo;
using SmaguciaiDomain.Entities;

namespace SmaguciaiAPI.Controllers;

public class PhotoController : BaseController
{
    private readonly IPhotoService _photoService;
    public PhotoController(IPhotoService photoService)
    {
        _photoService = photoService;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewPhoto(PhotoRequest request)
    {
        var res = await _photoService.AddNewPhoto(request);
        return Ok(res);
    }
    
    [HttpGet]
    public IActionResult GetAll(Guid productId)
    {
        return Ok(_photoService.GetAll(productId));
    }
}