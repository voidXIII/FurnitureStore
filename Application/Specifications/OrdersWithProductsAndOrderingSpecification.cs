using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Specifications
{
    public class OrdersWithProductsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithProductsAndOrderingSpecification(string userEmail) : base(o => o.Email == userEmail)
        {
            AddInclude(o => o.OrderedProducts);
            AddInclude(o => o.DeliveryType);
            AddOrderByDescending(o => o.DateOfOrder);
        }

        public OrdersWithProductsAndOrderingSpecification(int id, string userEmail) : base(o => o.Id == id && o.Email == userEmail)
        {
            AddInclude(o => o.OrderedProducts);
            AddInclude(o => o.DeliveryType);
        }
    }
}