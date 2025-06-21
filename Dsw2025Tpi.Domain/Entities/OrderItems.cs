using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class OrderItems
    {
        public OrderItems(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<Order>? Order { get; set; }
        public Product? ProductId { get; set; }

    }
}
