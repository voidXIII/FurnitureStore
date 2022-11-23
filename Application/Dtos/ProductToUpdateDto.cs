using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProductToUpdateDto
    {
        [Required]
        public string Model { get; set; }
        
        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Name is too short")]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public string Dimensions { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}