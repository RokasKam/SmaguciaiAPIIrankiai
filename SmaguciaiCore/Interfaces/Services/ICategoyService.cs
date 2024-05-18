using SmaguciaiCore.Requests.Category;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Category;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface ICategoryService
{
    List<CategoyResponse> GetAll();
    CategoyResponse GetById(Guid id);
    Guid AddCategory(CategoryRequest categoryRequest);
}