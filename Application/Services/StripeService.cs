using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Specifications;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Application.Services
{
    public class StripeService : IStripeService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IConfiguration _config;
        private readonly IRepository<Domain.Entities.Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<DeliveryType> _deliveryTypeRepo;
        public StripeService(IBasketRepository basketRepository, IConfiguration config, IRepository<Domain.Entities.Product> productRepo, IRepository<Order> orderRepo, IRepository<DeliveryType> deliveryTypeRepo)
        {
            _deliveryTypeRepo = deliveryTypeRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _config = config;
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> AddOrUpdateStripeIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var basket = await _basketRepository.GetBasketAsync(basketId);
            var deliveryPrice = 0m;

            if (basket.DeliveryTypeId.HasValue)
            {
                var deliveryType = await _deliveryTypeRepo.GetByIdAsync((int)basket.DeliveryTypeId);
                deliveryPrice = deliveryType.Price;
            }

            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            var service = new PaymentIntentService();

            PaymentIntent intent;
            
            if(string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + ((long) deliveryPrice * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) deliveryPrice * 100
                };

                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await _basketRepository.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _orderRepo.GetEntityWithSpec(spec);

            if (order == null) return null;

            order.Status = OrderStatus.PaymentFailed;

            await _orderRepo.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _orderRepo.GetEntityWithSpec(spec);

            if (order == null) return null;

            order.Status = OrderStatus.PaymentRecevied;
            _orderRepo.Update(order);

            await _orderRepo.SaveChangesAsync();

            return order;
        }
    }
}