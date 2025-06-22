using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Domain.Entities;

public class Product : EntityBase
{
    public Product(string sku, string name, decimal price, string descripcion, int stockQuantity, string internalCode)
    {
        Sku = sku;
        Name = name;
        CurrentUnitPrice = price;
        IsActive = true;
        InternalCode = internalCode;
        Descripcion = descripcion;
        StockQuantity = stockQuantity;
        productId = Guid.NewGuid();

    }

    public string? Sku { get; set; }
    public string? Name { get; set; }
    public decimal CurrentUnitPrice { get; set; }
    public bool IsActive { get; set; }
    public string InternalCode { get; set; }
    public string? Descripcion { get; set; }
    public int StockQuantity { get; set; }
    public Guid productId { get; }
}