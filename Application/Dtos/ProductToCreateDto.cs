using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProductToCreateDto
    {
        [Required]
        public string Model { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Name is too short")]
        public string ProductName { get; set; }

        [Required]
        public string ImageUrl {get; set;}

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1,3)]
        public int TopologyId {get; set; } = 1;

        [Required]
        [Range(1,3)]
        public int FunctionId { get; set; } = 1;

        [Required]
        public string Dimensions { get; set; }

        [Required]
        public string Description { get; set; }
    }
}