using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IProductRepository
{
    
    Product GetById(Guid id);
    Guid AddNewProduct(Product product, Category category);

    bool EditProduct(Product product);

    bool DeleteProduct(Product product, Category category);
    
    IEnumerable<Product> GetAll(ProductParameters productParameters);
    
    IEnumerable<Product> GetAllByCategory(Guid categoryId);
    
    IEnumerable<Product> GetAllByGender(Gender gender);

}