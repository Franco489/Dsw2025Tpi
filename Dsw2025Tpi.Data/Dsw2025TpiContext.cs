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
            entity.Property(p => p.CurrentUnitPrice).HasColumnType("decimal(18,2)");
            entity.Property(p => p.StockQuantity).IsRequired().HasMaxLength(6);
            entity.Property(p => p.IsActive).HasDefaultValue(true);
        });
        modelBuilder.Entity<Orders>(entity =>
        {
            entity.Property(o => o.shippingAddress).IsRequired().HasMaxLength(300);
            entity.Property(o => o.billingAddress).IsRequired().HasMaxLength(300);
            entity.Property(o => o.notes).HasMaxLength(200);
            entity.Property(o => o.date).IsRequired();
            entity.Property(o => o.totalAmount).HasColumnType("decimal(18,2)").IsRequired();
        });
    }
}
