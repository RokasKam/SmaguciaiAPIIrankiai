using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Responses.DiscountCode;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class DiscountCodeService : IDiscountCodeService
{
    private readonly IDiscountCodeRepository _discountCodeRepository;
    private readonly IMapper _mapper;
    
    public DiscountCodeService(IDiscountCodeRepository discountCodeRepository, IMapper mapper)
    {
        _discountCodeRepository = discountCodeRepository;
        _mapper = mapper;
    }
    
    public DiscountCodeResponse GetByCode(string code)
    {
        var report = _discountCodeRepository.GetByCode(code);
        var response = _mapper.Map<DiscountCodeResponse>(report);
        return response;
    }

    public bool DeleteDiscountCode(Guid id)
    {
        try
        {
            _discountCodeRepository.DeleteDiscountCode(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}