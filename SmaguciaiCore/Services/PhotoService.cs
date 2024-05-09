using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Photo;
using SmaguciaiCore.Responses.Photo;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    private readonly IProductRepository _productRepository;
    public PhotoService(IProductRepository productRepository, IMapper mapper, IPhotoRepository photoRepository,IImageService imageService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _imageService = imageService;
        _photoRepository = photoRepository;
    }
    
    public async Task<bool> AddNewPhoto(PhotoRequest request)
    {
        var photo = _mapper.Map<Photo>(request);
        var productName =  _productRepository.GetById(photo.ProductId).Name;
        Stream imageStream = _imageService.ConvertBase64ToStream(photo.URL);
        string imageFromFirebase = await _imageService.UploadImage(imageStream, Guid.NewGuid().ToString());
        photo.URL = imageFromFirebase;
        var res = _photoRepository.AddNewPhoto(photo);
        return res;
    }
    
    public IEnumerable<PhotoResponse> GetAll(Guid productId)
    {
        var photos = _photoRepository.GetAll(productId);
        var productsResponseList = photos.Select(x => _mapper.Map<PhotoResponse>(x)).ToList();
        return productsResponseList;
    }
}