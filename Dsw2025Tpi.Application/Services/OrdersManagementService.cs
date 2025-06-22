using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Services
{
    public class OrdersManagementService
    {
        private readonly IRepository _repository;

        public OrdersManagementService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<OrderModel.Response> CreateOrderAsync(OrderModel.Request orden)
        {
            var customer = await _repository.GetById<Customer>(orden.CustomerId);
            if (customer == null)
                throw new EntityNotFoundException("Customer not found");

            var items = new List<OrderItem>();

            foreach (var itemDto in orden.Items)
            {
                var product = await _repository.GetById<OrderItem>(itemDto.ProductId);
                if (product == null)
                    throw new EntityNotFoundException($"Product {itemDto.ProductId} not found");

                if (product.StockQuantity < itemDto.Quantity)
                    throw new InvalidOperationException($"Insufficient stock for product {product.Name}");

                product.StockQuantity -= itemDto.Quantity;
                await _productRepository.UpdateAsync(product);

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    UnitPrice = itemDto.UnitPrice
                };

                items.Add(orderItem);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = orden.CustomerId,
                ShippingAddress = orden.ShippingAddress,
                BillingAddress = orden.BillingAddress,
                Items = items,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);

            return _mapper.Map<OrderDto>(order);
        }


        /*
        public async Task<OrderModel.Response> CreateOrderAsync(OrderModel.Request request)
        {
            var customer = await _repository.GetById<Order>(request.CustomerId);
            if (customer == null)
                throw new EntityNotFoundException("Customer not found.");

            var orderItems = new List<OrderItem>();

            foreach (var item in request.Items)
            {
                var product = await _repository.GetById<Product>(item.ProductId);
                if (product == null)
                    throw new EntityNotFoundException($"El producto {item.ProductId} no existe.");

                if (product.StockQuantity < item.Quantity)
                    throw new InvalidOperationException($"Insufficient stock for product {product.Name}.");

                product.StockQuantity -= item.Quantity;

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });

                await _repository.Update(product); // persistir cambio de stock
            }

            var order = new Order(Id = Guid.NewGuid(),request.CustomerId, request. );

            
            var order = new Order( Id = Guid.NewGuid(),CustomerId = dto.CustomerId,ShippingAddress = dto.ShippingAddress,
                BillingAddress = dto.BillingAddress,Items = orderItems,Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            );
            await _repository.Add(order);
            return _mapper.Map<OrderDto>(order);

        }*/

    }
}
