using System;
using SmaguciaiCore.Interfaces.Repositories;
using Stripe;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiDomain.Entities;
using Stripe_Payments_Web_Api.Models.Stripe;

namespace SmaguciaiCore.Services
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly IOrderRepository _orderRepository;


        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService,
            IOrderRepository orderRepository)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Add a new payment at Stripe using Customer and Payment details.
        /// Customer has to exist at Stripe already.
        /// </summary>
        /// <param name="payment">Stripe Payment</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns><Stripe Payment/returns>
        public async Task <StripePayment> AddStripePaymentAsync(AddStripeCustomer customer, CancellationToken ct) 
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc
                }
            };
            
            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);
            
            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };
            
            // Create customer at Stripe
            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);
            Order order = _orderRepository.GetById(customer.OrderId);
            // Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions {
                Customer = createdCustomer.Id,
                ReceiptEmail = createdCustomer.Email,
                Description = "Paid for order: " + customer.OrderId.ToString(),
                Currency = "EUR",
                Amount = (long)order.WholePrice * 100
            };

            // Create the payment
            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            // Return the payment to requesting method
            _orderRepository.UpdatePayment(customer.OrderId);
            return new StripePayment(
                createdPayment.CustomerId,
                createdPayment.ReceiptEmail,
                createdPayment.Description,
                createdPayment.Currency,
                createdPayment.Amount,
                createdPayment.Id);
        }


    }
}