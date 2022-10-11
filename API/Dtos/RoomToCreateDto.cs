using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
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
        public int BookingStatusId {get; set; }

        [Required]
        [Range(1,4)]
        public int RoomTypeId { get; set; }
        public int RoomCapacity { get; set; }

        [Required]
        public string RoomDescription { get; set; }
    }
}