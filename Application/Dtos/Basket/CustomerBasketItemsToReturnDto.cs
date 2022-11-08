using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Basket
{
    public class CustomerBasketItemsToReturnDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Topology { get; set; }
    }
}