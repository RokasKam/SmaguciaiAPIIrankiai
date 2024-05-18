using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public ProductRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Product GetById(Guid id)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

        return product;
    }
    
    public Guid AddNewProduct(Product product, Category category)
    {
        product.Id = Guid.NewGuid();
        product.RatingAmount = 0;
        product.RatingAverage = 0;
        product.CreationDate = DateTime.Now;
        _dbContext.Products.Add(product);

        category.AmountOfProducts++;
        _dbContext.Entry(category).State = EntityState.Modified;
        
        _dbContext.SaveChanges();
        return product.Id;
    }
    public bool EditProduct(Product updatedProduct)
    {
        try
        {
            var existingProduct = _dbContext.Products.Include(p => p.Category)
                .FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            // Check if category has changed
            if (existingProduct.CategoryId != updatedProduct.CategoryId)
            {
                var oldCategory = _dbContext.Categories.Find(existingProduct.CategoryId);
                if (oldCategory != null && oldCategory.AmountOfProducts > 0)
                {
                    oldCategory.AmountOfProducts--;
                }

                var newCategory = _dbContext.Categories.Find(updatedProduct.CategoryId);
                if (newCategory != null)
                {
                    newCategory.AmountOfProducts++;
                }
            }
            
            _dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public bool DeleteProduct(Product product, Category category)
    {
        try
        {
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _dbContext.Products.Remove(product);

            category.AmountOfProducts = Math.Max(0, category.AmountOfProducts - 1);
            _dbContext.Entry(category).State = EntityState.Modified;

            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

        
    public IEnumerable<Product> GetAll(ProductParameters productParameters)
    {
        
        IQueryable<Product> entities = _dbContext.Products.Where(p => EF.Property<string>(p, "Discriminator") == "Product");;

        entities = entities
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize);

        return entities.ToList();
    }
}