using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order( Guid customerId, DateTime date, string shipingAddress, string billingAddress, string notes, List<OrderItem> items)
        {
            Id = ;
            CustomerId = customerId;
            Date = date;
            ShipingAddress = shipingAddress;
            BillingAddress = billingAddress;
            Notes = notes;
            Items = items;
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string ShipingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Notes { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public Guid CustomerId { get; set; }

    }
}
