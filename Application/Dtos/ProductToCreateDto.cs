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
        public string ImageUrl {get; set;}
        public decimal Price { get; set; }

        [Required]
        [Range(1,3)]
        public int TopologyId {get; set; } = 1;

        [Required]
        [Range(1,4)]
        public int FunctionId { get; set; } = 1;
        public string Dimensions { get; set; }

        [Required]
        public string Description { get; set; }
    }
}