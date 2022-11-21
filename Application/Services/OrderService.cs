using Application.Interfaces;
using Application.Specifications;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IStripeService _stripeService;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<DeliveryType> _deliveryTypeRepo;
        public OrderService(IBasketRepository basketRepo, IStripeService stripeService, 
            IRepository<Product> productRepo, IRepository<Order> orderRepo, IRepository<DeliveryType> deliveryTypeRepo)
        {
            _deliveryTypeRepo = deliveryTypeRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _stripeService = stripeService;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string userEmail, int deliveryTypeId, string basketId, Address address)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);

            if (basket == null) return null;

            var items = new List<OrderedProduct>();
            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var productOrdered = new ProductOrdered(productItem.Id, productItem.ProductName, productItem.ImageUrl);
                var orderedProduct = new OrderedProduct(productOrdered, productItem.Price, item.Quantity);
                items.Add(orderedProduct);
            }

            var deliveryType = await _deliveryTypeRepo.GetByIdAsync(deliveryTypeId);

            var sum = items.Sum(item => item.Price * item.Quantity);

            var spec = new OrderWithPaymentIntentIdSpecification(basket.PaymentIntentId);
            var existingOrder = await _orderRepo.GetEntityWithSpec(spec);

            if (existingOrder != null)
            {
                _orderRepo.Delete(existingOrder);
                await _stripeService.AddOrUpdateStripeIntent(basket.PaymentIntentId);
            }

            var order = new Order(userEmail, address, deliveryType, items, sum, basket.PaymentIntentId);

            _orderRepo.Add(order);

            await _orderRepo.SaveChangesAsync();

            return order;
        }

        public async Task<IReadOnlyList<Order>> GerOrdersForUserAsync(string userEmail)
        {
            var spec = new OrdersWithProductsAndOrderingSpecification(userEmail);
            return await _orderRepo.ListAsync(spec);
        }

        public async Task<IReadOnlyList<DeliveryType>> GetDeliveryTypeAsync()
        {
            return await _deliveryTypeRepo.ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string userEmail)
        {
            var spec = new OrdersWithProductsAndOrderingSpecification(id, userEmail);
            return await _orderRepo.GetEntityWithSpec(spec);
        }
    }
}