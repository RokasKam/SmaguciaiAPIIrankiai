namespace SmaguciaiCore.Interfaces.Services;

public interface IDiscountCodeEmailService
{
    public bool EmailSendingFunction(string email, string discountCode, DateTime expirationDate);

}