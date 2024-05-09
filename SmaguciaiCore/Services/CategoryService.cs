using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Category;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public List<CategoyResponse> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        var categoryresposelist = categories.Select(x => _mapper.Map<CategoyResponse>(x)).ToList();
        return categoryresposelist;
    }
    
    public CategoyResponse GetById(Guid id)
    {
        var category = _categoryRepository.GetById(id);
        var response = _mapper.Map<CategoyResponse>(category);
        return response;
    }
}