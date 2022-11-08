using Application.Interfaces;
using Application.Specifications;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepo)
        {
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string userEmail, int deliveryTypeId, string basketId, Address address)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);

            var items = new List<OrderedProduct>();
            foreach(var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productOrdered = new ProductOrdered(productItem.Id, productItem.ProductName, productItem.ImageUrl);
                var orderedProduct = new OrderedProduct(productOrdered, productItem.Price, item.Quantity);
                items.Add(orderedProduct);
            }

            var deliveryType = await _unitOfWork.Repository<DeliveryType>().GetByIdAsync(deliveryTypeId);

            var sum = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(userEmail, address, deliveryType, items, sum);

            _unitOfWork.Repository<Order>().Add(order);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return null;

            await _basketRepo.DeleteBasketAsync(basketId);

            return order;
        }

        public async Task<IReadOnlyList<Order>> GerOrdersForUserAsync(string userEmail)
        {
            var spec = new OrdersWithProductsAndOrderingSpecification(userEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }

        public async Task<IReadOnlyList<DeliveryType>> GetDeliveryTypeAsync()
        {
            return await _unitOfWork.Repository<DeliveryType>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string userEmail)
        {
            var spec = new OrdersWithProductsAndOrderingSpecification(id, userEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }
    }
}