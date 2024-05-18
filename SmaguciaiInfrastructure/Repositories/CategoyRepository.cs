using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public CategoryRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Category GetById(Guid id)
    {
        var category = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
        return category;  
    }

    public Guid Add(Category category)
    {
        category.Id = Guid.NewGuid();
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return category.Id;
    }

    public List<Category> GetAll()
    {
        
        IQueryable<Category> entities = _dbContext.Categories;

        return entities.ToList();
    }
}