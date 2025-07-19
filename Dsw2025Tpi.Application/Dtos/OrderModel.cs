using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Application.Dtos;

   public record OrderModel
   {
       public record Request(Guid CustomerId, string ShippingAddress, string BillingAddress,
           List<OrderItemModel.Request> Items, OrderStatus Status, DateTime Date);

       public record Response(Guid CustomerId, string ShippingAddress, string BillingAddress,
            List<OrderItemModel.Response> Items, OrderStatus Status, DateTime Date);

   }
