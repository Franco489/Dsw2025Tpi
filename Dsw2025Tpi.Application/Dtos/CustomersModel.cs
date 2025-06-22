using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record CustomersModel
    {
        public record Request(Guid Id, string Email, string Name, string PhoneNumber);
        public record Response(Guid Id, string Email, string Name, string PhoneNumber);
    }
}
