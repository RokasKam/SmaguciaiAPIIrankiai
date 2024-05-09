using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class OrderProductService : IOrderProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly IMapper _mapper;
    
    public OrderProductService(IProductRepository productRepository, IMapper mapper, IOrderProductRepository orderProductRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _orderProductRepository = orderProductRepository;
    }
    
    public bool AddNewOrderProduct(OrderProductRequest orderProductRequest)
    {
        var product = _productRepository.GetById(orderProductRequest.ProductId);
        if (product.Amount < orderProductRequest.Amount)
            return false;
        var orderProduct = _mapper.Map<OrderPorduct>(orderProductRequest);
        var res = _orderProductRepository.AddNewOrderProduct(orderProduct);
        return res;
    }
}