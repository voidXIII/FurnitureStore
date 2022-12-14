using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderedProduct : BaseEntity
    {
        public OrderedProduct()
        {
        }

        public OrderedProduct(ProductOrdered productOrdered, decimal price, int quantity)
        {
            ProductOrdered = productOrdered;
            Price = price;
            Quantity = quantity;
        }

        public ProductOrdered ProductOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}