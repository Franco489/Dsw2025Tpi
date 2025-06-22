using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Order
    {
        public Order(DateTime date, string shipingAddress, string billingAddress, string notes)
        {
            Date = date;
            ShipingAddress = shipingAddress;
            BillingAddress = billingAddress;
            Notes = notes;
        }

        public DateTime Date { get; set; }
        public string ShipingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Notes { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
        public Guid CustomerId { get; set; }

    }
}
