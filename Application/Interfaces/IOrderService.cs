using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string userEmail, int deliveryType, string basketId, Address address);
        Task<IReadOnlyList<Order>> GerOrdersForUserAsync(string userEmail);
        Task<Order> GetOrderByIdAsync(int id, string userEmail);
        Task<IReadOnlyList<DeliveryType>> GetDeliveryTypeAsync();
    }
}