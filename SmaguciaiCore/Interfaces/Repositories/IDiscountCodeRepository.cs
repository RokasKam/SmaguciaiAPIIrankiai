using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IDiscountCodeRepository
{
    DiscountCode GetByCode(string code);
    bool DeleteDiscountCode(Guid id);
}