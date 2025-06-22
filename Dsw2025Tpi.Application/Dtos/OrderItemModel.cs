using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderItems
    {
        public record Request(DateTime Date, string ShipingAddress, string BillingAddress, string Notes);
        public record Response(DateTime Date, string ShipingAddress, string BillingAddress, string Notes, Guid ID);
    }
}
