using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IProductService
{
    Task<Guid> AddNewProduct(ProductRequest request);
    bool EditProduct(Guid id,ProductRequest request);
    
    ProductResponse GetById(Guid id);

    bool DeleteProduct(Guid id);
    
    List<ProductResponse> GetAll(ProductParameters productParameters);
    List<ProductResponse> GetRecommended(Guid userId);

}