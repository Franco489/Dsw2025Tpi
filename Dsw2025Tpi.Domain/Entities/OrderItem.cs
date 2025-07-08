using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities;

public class OrderItem : EntityBase
{
    public int quantity { get; set; }
    public decimal unitPrice { get; set; }
    public decimal subtotal { get; set; }

    //Aqui habria que expresar la relacion o alguna llave foranea del producto donde esta asociado
}
