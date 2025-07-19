using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities;

public class OrderItem : EntityBase
{
    public OrderItem()
    {
        
    }
    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Order? Order { get; set; }
    public Guid OrderId { get; set; }
    public Product? Product { get; set; }
    public Guid ProductId { get; set; }
    public decimal Subtotal => Quantity * UnitPrice;
    
}
