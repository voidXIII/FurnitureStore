using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class RoomToUpdateDto
    {
        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Name is too short")]
        public string RoomName { get; set; }

        [Required]
        public decimal RoomPrice { get; set; }

        public int RoomCapacity { get; set; }
        
        [Required]
        public string RoomDescription { get; set; }
    }
}