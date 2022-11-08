using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Dtos
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfOrder { get; set; }
        public Address Address { get; set; }
        public string DeliveryType { get; set; }
        public decimal DeliveryPrice { get; set; }
        public IReadOnlyList<OrderedProductDto> OrderedProducts{ get; set; }
        public decimal Sum { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}