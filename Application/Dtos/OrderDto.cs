using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryTypeId { get; set; }
        public AddressDto Address { get; set; }
    }
}