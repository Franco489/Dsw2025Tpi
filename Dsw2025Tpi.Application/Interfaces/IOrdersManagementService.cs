using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Interfaces
{
    public interface IOrdersManagementService
    {
        Task<OrderModel.Response> CreateOrderAsync(OrderModel.OrderRequest request);
        Task<OrderModel.Response> GetOrderById(Guid id);
        Task<IEnumerable<OrderModel.Response>?> GetAllOrders();
        Task<OrderModel.Response> UpdateOrderStatus(Guid id, string newStatus);
        Task<OrderModel.Response> DeleteOrder(Guid id);

    }
}
