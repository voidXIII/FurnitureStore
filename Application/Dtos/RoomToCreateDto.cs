using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class RoomToCreateDto
    {
        [Required]
        public int RoomNumber { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Name is too short")]
        public string RoomName { get; set; }

        [Required]
        public string RoomMainImageUrl { get; set; }
        public decimal RoomPrice { get; set; }

        [Required]
        [Range(1,3)]
        public int BookingStatusId {get; set; } = 1;

        [Required]
        [Range(1,4)]
        public int RoomTypeId { get; set; } = 1;
        public int RoomCapacity { get; set; }

        [Required]
        public string RoomDescription { get; set; }
    }
}