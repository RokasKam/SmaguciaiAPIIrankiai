using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Category;
using SmaguciaiCore.Requests.Product;

namespace SmaguciaiAPI.Controllers;

public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAll());
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_categoryService.GetById(id));
    }
    [HttpPost]
    public IActionResult AddNew(CategoryRequest categoryRequest)
    {
        return Ok(_categoryService.AddCategory(categoryRequest));
    }
}