using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Domain.Interfaces;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Services;

public class ProductsManagementService
{
    private readonly IRepository _repository;

    public ProductsManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductModel.Response?> GetProductById(Guid id)
    {
        var product = await _repository.GetById<Product>(id);
        return product != null ?
            new ProductModel.Response(product.Sku, product.Name, product.CurrentUnitPrice, product.Descripcion, product.StockQuantity, product.ProductId) :
            null;
    }

    public async Task<IEnumerable<ProductModel.Response>?> GetProducts()
    {
        return (await _repository
            .GetFiltered<Product>(p => p.IsActive))?
            .Select(p => new ProductModel.Response(p.Sku, p.Name,
            p.CurrentUnitPrice, p.Descripcion, p.StockQuantity, p.ProductId));
    }

    public async Task<ProductModel.Response> AddProduct(ProductModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Sku) ||
            string.IsNullOrWhiteSpace(request.Name) ||
            request.Price < 0)
        {
            throw new ArgumentException("Valores para el producto no válidos");
        }

        var exist = await _repository.First<Product>(p => p.Sku == request.Sku);
        if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");
        var product = new Product(request.Sku, request.Name, request.Price, request.Descripcion, request.StockQuantity, request.ProductId);
        await _repository.Add(product);
        return new ProductModel.Response(product.Sku, product.Name,
            product.CurrentUnitPrice, product.Descripcion, product.StockQuantity, product.ProductId);
    }
}
