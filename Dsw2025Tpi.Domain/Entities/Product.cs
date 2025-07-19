using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Domain.Entities;

public class Product : EntityBase
{
    public Product()
    {
        
    }
    public Product(string sku, string name, decimal price, string descripcion, int stockQuantity, string internalCode)
    {
        //ProductId = productId;
        Sku = sku;
        Name = name;
        CurrentUnitPrice = price;
        IsActive = true;
        Description = descripcion;
        StockQuantity = stockQuantity;
        InternalCode = internalCode;

    }
    //public Guid ProductId { get; set; }
    public string?  Sku { get; set; }
    public string? Name { get; set; }
    private decimal _currentUnitPrice;
    public decimal CurrentUnitPrice
    {
        get => _currentUnitPrice;
        set
        {
            if(value<=0)
                throw new ApplicationException("El precio no puede ser negativo");
            
            _currentUnitPrice = value;
        }
    }
    public bool IsActive { get; set; }
   public string? InternalCode { get; set; }
    public string? Description { get; set; }
    private int _stockQuantity;
    public int StockQuantity 
    {
        get => _stockQuantity;
        set 
        {
            if(value<0)
            {
                throw new ApplicationException("El stock no puede ser negativo");
            }
            _stockQuantity = value;
        } 
    }
    public ICollection<OrderItem>? OrderItems { get; set; }

}
