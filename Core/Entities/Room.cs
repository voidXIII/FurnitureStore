using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string RoomMainImageUrl { get; set; }
        public decimal RoomPrice { get; set; }
        public int BookingStatusId { get; set; }
        public BookingStatus BookingStatus {get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }
    }
}