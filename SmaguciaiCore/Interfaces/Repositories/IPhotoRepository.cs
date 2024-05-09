using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IPhotoRepository
{
   bool AddNewPhoto(Photo photo);
   IEnumerable<Photo> GetAll(Guid productId);
   void DeleteByProductId(Guid id);
}