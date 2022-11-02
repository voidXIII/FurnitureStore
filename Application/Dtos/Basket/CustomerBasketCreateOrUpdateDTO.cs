using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Basket
{
    public class CustomerBasketCreateOrUpdateDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public List<CustomerBasketItemsToReturnDto> Items { get; set; }
    }
}