using SmaguciaiCore.Responses.DiscountCode;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IDiscountCodeService
{
    // deletas ir visa info pagal koda
    DiscountCodeResponse GetByCode(string code);
    bool DeleteDiscountCode(Guid id);
}