namespace Dsw2025Tpi.Domain.Entities;

// Queda despues a analizar si los shippingAdress y billingAdress tiene sentido que sean necesarios si o si

public class Order : EntityBase
{
    public DateTime Date { get; set; }
    public required string ShippingAddress { get; set; }
    public required string BillingAdress { get; set; }
    public string? Notes { get; set; }
    public decimal totalAmount { get; set; }

    public OrderStatus orderStatus;

    public Order(DateTime date, string shippingAddress, string billingAdress, string? notes, decimal totalAmount, OrderStatus orderStatus)
    {
        Date = date;
        ShippingAddress = shippingAddress;
        BillingAdress = billingAdress;
        Notes = notes;
        this.totalAmount = totalAmount;
        this.orderStatus = orderStatus;
    }
}
