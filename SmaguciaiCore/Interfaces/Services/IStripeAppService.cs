using System;
using Stripe_Payments_Web_Api.Models.Stripe;

namespace SmaguciaiCore.Interfaces.Services
{
    public interface IStripeAppService
    {
        Task<StripePayment> AddStripePaymentAsync(AddStripeCustomer customer, CancellationToken ct);

    }
}