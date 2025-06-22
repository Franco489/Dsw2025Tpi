using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderModel
    {
        public record Request(int quantity, decimal unitPrice);

        public record Response(int quantity, decimal unitPrice, decimal subTotal);
    }
}
