using System.Globalization;
using System.Text.RegularExpressions;
using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Auction;
using SmaguciaiCore.Responses.Auctions;
using SmaguciaiDomain.Entities;
using Stripe_Payments_Web_Api.Models.Stripe;

namespace SmaguciaiCore.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;
    private readonly IBidRepository _bidRepository;
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IStripeAppService _stripeAppService;
    private readonly IUserRepository _userRepository;
    
    public AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IBidRepository bidRepository, IOrderProductRepository orderProductRepository, IOrderRepository orderRepository, IStripeAppService stripeAppService, IUserRepository userRepository)
    {
        _auctionRepository = auctionRepository;
        _mapper = mapper;
        _bidRepository = bidRepository;
        _orderProductRepository = orderProductRepository;
        _orderRepository = orderRepository;
        _stripeAppService = stripeAppService;
        _userRepository = userRepository;
    }

    public Guid AddNew(AuctionRequest auctionRequest)
    {
        var response = _mapper.Map<Auction>(auctionRequest);
        return _auctionRepository.AddNew(response);
    }

    public AuctionResponse GetById(Guid id)
    {
        var product = _auctionRepository.GetById(id);
        var productResponse = _mapper.Map<AuctionResponse>(product);
        return productResponse;
    }

    public List<AuctionResponse> GetAll()
    {
        var products = _auctionRepository.GetAll();
        var productsResponseList = products.Select(x => _mapper.Map<AuctionResponse>(x)).ToList();
        return productsResponseList;
    }

    public async Task<bool> ChooseWinner()
    {
        var finished = _auctionRepository.GetAll().Where(a => a.FinishTime < DateTime.Now).ToList();
        while (finished.Count != 0)
        {
            var bids = _bidRepository.GetAllAuctionBid(finished.First().Id).OrderByDescending(b=>b.Time).ToList();
            while (bids.Count != 0)
            {
                if (Validate(bids.First()))
                {
                    var finalPrice = (decimal)(bids.First().BidSum + 5);
                    var user = _userRepository.GetById(bids.First().UserId);
                    var id = _orderRepository.AddNewOrder(new Order
                    { 
                        WholePrice = finalPrice,
                        WholeAmount = 1,
                        UserId = bids.First().UserId
                    });
                    finished.First().Price = (decimal)bids.First().BidSum;
                    _orderProductRepository.AddNewOrderProduct(new OrderPorduct
                    { 
                        Amount = 1,
                        ProductId = finished.First().Id,
                        OrderId = id,
                    });
                    var res = await _stripeAppService.AddStripePaymentAsync(new AddStripeCustomer
                    (
                        Email: user.Email,
                        Name: user.Name,
                        OrderId: id,
                        CreditCard: new AddStripeCard
                        (
                            Name: bids.First().UserName,
                            CardNumber: bids.First().CardNumber,
                            ExpirationYear: bids.First().ExpDate.Split('/')[1],
                            ExpirationMonth:  bids.First().ExpDate.Split('/')[0],
                            Cvc: bids.First().CVC
                        )
                    ), CancellationToken.None);
                    if (res.PaymentId != "")
                    {
                        _auctionRepository.UpdateStatus(finished.First().Id);
                        break;
                    }
                }
                bids.Remove(bids.First());
            }
            if (bids.Count == 0)
            {
                _auctionRepository.UpdateFinishDate(finished.First().Id);
            }

            finished.Remove(finished.First());
        }

        return true;
    }
    
    public bool Validate(Bid bid)
    {
        if (string.IsNullOrWhiteSpace(bid.CardNumber))
        {
            return false;
        }

        if (!Regex.IsMatch(bid.CardNumber, @"^\d{16}$"))
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(bid.UserName))
        {
            return false;
        }

        if (bid.UserName.Length > 100)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(bid.CVC))
        {
            return false;
        }

        if (!Regex.IsMatch(bid.CVC, @"^\d{3,4}$"))
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(bid.ExpDate))
        {
            return false;
        }

        if (!DateTime.TryParseExact(bid.ExpDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            return false;
        }

        if (parsedDate <= DateTime.Now)
        {
            return false;
        }

        return true;
    }
}