using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Photo;
using SmaguciaiCore.Responses.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPhotoRepository _photoRepository;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository, IPhotoRepository photoRepository, IImageService imageService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _photoRepository = photoRepository;
        _imageService = imageService;
    }
    
    public ProductResponse GetById(Guid id)
    {
        var product = _productRepository.GetById(id);
        var productResponse = _mapper.Map<ProductResponse>(product);
        var photos = _photoRepository.GetAll(id);
        var productsResponseList = photos.Select(x => _mapper.Map<PhotoResponse>(x)).ToList();
        productResponse.Photos = productsResponseList;
        return productResponse;
    }
    
    public async Task<Guid> AddNewProduct(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        var category = _categoryRepository.GetById(request.CategoryId);
        var res = _productRepository.AddNewProduct(product, category);
        foreach (var photor in request.PhotosReq)
        {
            var photo = _mapper.Map<Photo>(photor);
            photo.ProductId = res;
            Stream imageStream = _imageService.ConvertBase64ToStream(photo.URL);
            string imageFromFirebase = await _imageService.UploadImage(imageStream, Guid.NewGuid().ToString());
            photo.URL = imageFromFirebase;
            _photoRepository.AddNewPhoto(photo);
        }
        
        return res;
    }
    public bool EditProduct(Guid id,ProductRequest request)
    {
        try
        {
            var productToUpdate = _productRepository.GetById(id);
            if (productToUpdate is null)
            {
                throw new Exception("Place with provided id does not exist");
            }

            var product = _mapper.Map<Product>(request);
            product.Id = id;
            var res = _productRepository.EditProduct(product);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteProduct(Guid id)
    {
        try
        {
            var productToDelete = _productRepository.GetById(id);
            if (productToDelete == null)
            {
                throw new Exception("Product not found");
            }

            var category = _categoryRepository.GetById(productToDelete.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            
            _productRepository.DeleteProduct(productToDelete, category);
            _photoRepository.DeleteByProductId(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public List<ProductResponse> GetAll(ProductParameters productParameters)
    {
        var products = _productRepository.GetAll(productParameters);
        var productsResponseList = products.Select(x => _mapper.Map<ProductResponse>(x)).ToList();
        return productsResponseList;
    }
}