using SmaguciaiCore.Requests.Photo;
using SmaguciaiCore.Responses.Photo;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IPhotoService
{
   Task<bool> AddNewPhoto(PhotoRequest request);
   
   IEnumerable<PhotoResponse> GetAll(Guid productId);
}