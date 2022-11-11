using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Basket
{
    public class CustomerBasketCreateOrUpdateDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public List<CustomerBasketItemsToReturnDto> Items { get; set; }
        public int? DeliveryTypeId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}