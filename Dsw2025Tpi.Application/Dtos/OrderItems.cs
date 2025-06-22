using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderItems
    {
        public record Request(DateTime date, string shipingAddress, string billingAddress, string notes);
        public record Response(DateTime date, string shipingAddress, string billingAddress, string notes, Guid ID);
    }
}
