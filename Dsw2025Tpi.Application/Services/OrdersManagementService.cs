using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Services;

public class OrdersManagementService
{
    private readonly IRepository _repository;

    public OrdersManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrderModel.Response> CreateOrder(OrderModel.Request orden)
    {
        var customer = await _repository.GetById<Customer>(orden.CustomerId);

        var items = new List<OrderItem>();

        foreach (var item in orden.Items)
        {
            var product = await _repository.GetById<Product>(item.ProductId);
            if (product == null)
                throw new EntityNotFoundException($"El producto '{item.ProductId}' no se encontró");

            if (product.StockQuantity < item.Quantity)
                throw new ApplicationException($"Stock insuficinete del producto: {product.Name}");


            product.StockQuantity -= item.Quantity;
            await _repository.Update(product);

            items.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            });
        }
            var order = new Order
            {
                CustomerId = orden.CustomerId,
                ShippingAddress = orden.ShippingAddress,
                BillingAddress = orden.BillingAddress,
                Date = orden.Date,
                Status = orden.Status,
                OrderItems = items                
            };


        await _repository.Add(order);

        return new OrderModel.Response(order.CustomerId, order.ShippingAddress, order.BillingAddress,
             order.OrderItems.Select(item => new OrderItemModel.Response
             (item.ProductId, item.Quantity, item.UnitPrice)).ToList(), order.Status, order.Date);

    }

}
