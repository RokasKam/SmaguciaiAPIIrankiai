using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category GetById(Guid id);
}