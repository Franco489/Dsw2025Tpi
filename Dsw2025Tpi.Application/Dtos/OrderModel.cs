using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderModel
    {
        public record Request(int Quantity, decimal UnitPrice);

        public record Response(int Quantity, decimal UnitPrice, decimal SubTotal);
    }
}
