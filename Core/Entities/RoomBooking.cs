using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RoomBooking : BaseEntity
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AssignRoomId { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal FinalPrice { get; set; }
    }
}