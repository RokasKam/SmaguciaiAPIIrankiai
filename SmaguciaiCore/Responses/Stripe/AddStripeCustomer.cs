using System;
namespace Stripe_Payments_Web_Api.Models.Stripe
{
    public record AddStripeCustomer(
        string Email,
        string Name,
        Guid OrderId,
        AddStripeCard CreditCard);
}