using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities;

public class OrderItem : EntityBase
{
    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public ICollection<Order>? Order { get; set; }
    public Product? Product { get; set; }
    public Guid ProductId { get; set; }
    public int Subtotal =>(int)(Quantity * UnitPrice);
    
}
