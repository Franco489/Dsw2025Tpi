using Dsw2025Tpi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2025Tpi.Data;

public class Dsw2025TpiContext: DbContext
{
    public Dsw2025TpiContext(DbContextOptions<Dsw2025TpiContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Sku).IsRequired().HasMaxLength(50);
            entity.Property(p => p.InternalCode).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Descripcion).HasMaxLength(500);
            entity.Property(p => p.CurrentUnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.StockQuantity).IsRequired().HasMaxLength(6);
            entity.Property(p => p.IsActive).HasDefaultValue(true);
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(o => o.ShipingAddress).IsRequired().HasMaxLength(300);
            entity.Property(o => o.BillingAddress).IsRequired().HasMaxLength(300);
            entity.Property(o => o.Notes).HasMaxLength(200);
            entity.Property(o => o.Date).IsRequired();
            entity.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
        });
        modelBuilder.Entity<OrderItems>(entity =>
        {
            entity.Property(i => i.Quantity).IsRequired().HasMaxLength(300);
            entity.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(i => i.Subtotal).HasColumnType("decimal(18,2)");
        });
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(c => c.Email).IsRequired().HasMaxLength(300);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
            entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
        });
    }
}
