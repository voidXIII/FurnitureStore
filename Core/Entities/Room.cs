using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string RoomMainImage { get; set; }
        public decimal RoomPrice { get; set; }
        public int BookingStatusId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }
    }
}