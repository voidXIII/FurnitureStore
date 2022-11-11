using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Specifications
{
    public class OrderWithPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}