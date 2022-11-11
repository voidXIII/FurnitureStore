using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(string email, Address address, DeliveryType deliveryType, IReadOnlyList<OrderedProduct> orderedProducts, decimal sum, string paymentIntentId)
        {
            Email = email;
            Address = address;
            DeliveryType = deliveryType;
            OrderedProducts = orderedProducts;
            Sum = sum;
            PaymentIntentId = paymentIntentId;
        }

        public string Email { get; set; }
        public DateTimeOffset DateOfOrder { get; set; } = DateTimeOffset.Now;
        [Required]
        public Address Address { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public IReadOnlyList<OrderedProduct> OrderedProducts{ get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.InProgress;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return Sum + DeliveryType.Price;
        }
    }
}