using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool IsActive { get; set; }
    }
}