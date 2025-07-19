using Dsw2025Tpi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2025Tpi.Data;

public class Dsw2025TpiContext: DbContext
{

    public Dsw2025TpiContext(DbContextOptions<Dsw2025TpiContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(eb =>
        {
            eb.ToTable("Products");

            eb.Property(p => p.Sku)
            .HasMaxLength(15)
            .IsRequired();

            eb.Property(p => p.Name)
             .HasMaxLength(100)
             .IsRequired();

            eb.Property(p => p.CurrentUnitPrice)
             .HasPrecision(10, 2);

            eb.Property(p => p.Description)
            .HasMaxLength(100);

            eb.Property(p => p.InternalCode)
            .HasMaxLength(15);
        });


        modelBuilder.Entity<Order>(eb =>
        {
            eb.ToTable("Orders");

            eb.Property(o => o.Notes)
            .HasMaxLength(100);

            eb.Property(o => o.BillingAddress)
            .HasMaxLength(100);

            eb.Property(o => o.ShippingAddress)
            .HasMaxLength(100);

        });


        modelBuilder.Entity<Customer>(c =>
        {
            c.ToTable("Customers");
            c.Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired();
            c.Property(c => c.Email)
            .HasMaxLength(60);

        });



        modelBuilder.Entity<OrderItem>(oi =>
        {
            oi.ToTable("OrderItems");

            oi.Property(oi => oi.UnitPrice)
            .HasPrecision(5, 2);
        });

    }
}
