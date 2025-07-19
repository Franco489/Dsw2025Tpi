using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            
        }
        public Order(Guid customerId, DateTime date, string shippingAddress, string billingAddress, string notes, List<OrderItem> items)
        {
            CustomerId = customerId;
            Date = date;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            Notes = notes;
            OrderItems = items;
        }
        
        public DateTime Date { get; set; }
        public string? ShippingAddress { get; set; }
        public string? BillingAddress { get; set; }
        public string? Notes { get; set; }
        public decimal TotalAmount => OrderItems?.Sum(p => p.Subtotal) ?? 0;
        public ICollection<OrderItem>? OrderItems { get; set; }
        public Customer? Customer { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }

    }
}
