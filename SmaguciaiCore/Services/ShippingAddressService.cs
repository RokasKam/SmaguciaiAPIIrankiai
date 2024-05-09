using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Requests.ShippingAddress;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ShippingAddressService : IShippingAddressService
{
    private readonly IShippingAddressRepository _shippingAddressRepository;
    private readonly IMapper _mapper;
    
    public ShippingAddressService(IShippingAddressRepository shippingAddressRepository, IMapper mapper)
    {
        _shippingAddressRepository = shippingAddressRepository;
        _mapper = mapper;
    }
    public bool AddNewShippingAddress(ShippingAddressRequest request)
    {
        var shippingAddress = _mapper.Map<ShippingAddress>(request);
        var res = _shippingAddressRepository.AddNewShippingAddress(shippingAddress);
        return res;
    }
    
    public ShippingAddressResponse GetById(Guid id)
    {
        var shippingAddress = _shippingAddressRepository.GetByUserId(id);
        var response = _mapper.Map<ShippingAddressResponse>(shippingAddress);
        return response;
    }
    public bool EditShippingAddress(Guid id,ShippingAddressRequest request)
    {
        var placeToUpdate = _shippingAddressRepository.GetById(id);
        if (placeToUpdate is null) 
        { 
            throw new Exception("Place with provided id does not exist");
        }

        var shippingAddress = _mapper.Map<ShippingAddress>(request);
        shippingAddress.Id = id;
        var res = _shippingAddressRepository.EditShippingAddress(shippingAddress);
        return true;
    }

    public bool DeleteShippingAddress(Guid id)
    {
        try
        {
            _shippingAddressRepository.DeleteShippingAddress(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}