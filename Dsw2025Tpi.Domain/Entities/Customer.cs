using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Customers
    {
        public Customers(string email, string name, string phoneNumber, Guid customerId)
        {
            CustomerId = customerId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
