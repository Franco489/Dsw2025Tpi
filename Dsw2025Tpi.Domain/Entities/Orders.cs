using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Orders : EntityBase
    {
        public string shippingAddress { get; set; }
        public string billingAddress { get; set; }
        public string notes { get; set; }
        public DateTime date { get; set; }
        public decimal totalAmount { get; set; }
        public Orders() { }

        public Orders(string ShippingAddress, string BillingAddress, string Notes, DateTime Date, decimal TotalAmount)
        {
            shippingAddress = ShippingAddress;
            billingAddress = BillingAddress;
            notes = Notes;
            date = Date;
            totalAmount = TotalAmount;
            Guid.NewGuid();
        }
    }
}
