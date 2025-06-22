using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Domain.Entities;

public class Product : EntityBase
{
    public Product(string sku, string name, decimal price, string descripcion, int stockQuantity, string internalCode, Guid productId)
    {
        Sku = sku;
        Name = name;
        CurrentUnitPrice = price;
        IsActive = true;
        ProductId = productId;
        Descripcion = descripcion;
        StockQuantity = stockQuantity;
        InternalCode = internalCode;

    }
    public Guid ProductId { get; set; }
    public string?  Sku { get; set; }
    public string? Name { get; set; }
    public decimal CurrentUnitPrice
    {
        get => CurrentUnitPrice;
        set
        {
            if(value<=0)
            {
                throw new ArgumentException("El precio no puede ser negativo");
            }
        }
    }
    public bool IsActive { get; set; }
   public string InternalCode { get; set; }
    public string? Descripcion { get; set; }
    public int StockQuantity 
    {
        get => StockQuantity;
        set 
        {
            if(value<0)
            {
                throw new ArgumentException("El stock no puede ser negativo");
            }
        } 
    }
    public ICollection<OrderItem>? OrderItems { get; set; }

}
