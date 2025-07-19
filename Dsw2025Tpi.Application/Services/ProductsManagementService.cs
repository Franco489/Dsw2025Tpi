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

        return product == null ?
            throw new EntityNotFoundException("No se encontró el producto") :
            new ProductModel.Response(product.Sku, product.Name, product.InternalCode, product.Description,
            product.CurrentUnitPrice, product.StockQuantity, product.Id);
    }

    public async Task<IEnumerable<ProductModel.Response>?> GetProducts()
    {
        return (await _repository.GetFiltered<Product>(p => p.IsActive))?.Select(p => new ProductModel.Response
        (p.Sku, p.InternalCode, p.Name, p.Description,
            p.CurrentUnitPrice, p.StockQuantity, p.Id));
    }

    public async Task<ProductModel.Response> AddProduct(ProductModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Sku) || string.IsNullOrWhiteSpace(request.InternalCode) ||
            string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0 || request.StockQuantity < 0 )
        {
            throw new ApplicationException("Valores para el producto no válidos");
        }

        //Tratar de mejorar
        var exist = await _repository.First<Product>(p => p.Sku == request.Sku);
        if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");
        var name = await _repository.First<Product>(p => p.Name == request.Name);
        if (name != null) throw new DuplicatedEntityException($"Ya existe un producto con el Nombre {request.Name}");
        var code = await _repository.First<Product>(p => p.InternalCode == request.InternalCode);
        if (code != null) throw new DuplicatedEntityException($"Ya existe un producto con el Codigo {request.InternalCode}");
        //

        var product = new Product(request.Sku, request.Name, request.Price, request.Description, request.StockQuantity,request.InternalCode);
        await _repository.Add(product);
        return new ProductModel.Response(product.Sku, product.InternalCode, product.Name, product.Description,
            product.CurrentUnitPrice, product.StockQuantity, product.Id);
    }

    public async Task<ProductModel.Response> UpdateProduct (Guid id, ProductModel.Request request)
    {

        var product = await _repository.GetById<Product>(id);

        if (product == null) throw new EntityNotFoundException("No se encontró el producto");


        if (string.IsNullOrWhiteSpace(request.Sku) || string.IsNullOrWhiteSpace(request.InternalCode) ||
           string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0 || request.StockQuantity < 0)
        {
            throw new ApplicationException("Valores para el producto no válidos");
        }

        //Tratar de mejorar
        var exist = await _repository.First<Product>(p => p.Sku == request.Sku && p.Id != id);
        if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");
        var name = await _repository.First<Product>(p => p.Name == request.Name && p.Id != id);
        if (name != null) throw new DuplicatedEntityException($"Ya existe un producto con el Nombre {request.Name}");
        var code = await _repository.First<Product>(p => p.InternalCode == request.InternalCode && p.Id != id);
        if (code != null) throw new DuplicatedEntityException($"Ya existe un producto con el Codigo {request.InternalCode}");
        //

        product.Sku = request.Sku;
        product.InternalCode = request.InternalCode;
        product.Name = request.Name;
        product.Description = request.Description;
        product.CurrentUnitPrice = request.Price;
        product.StockQuantity = request.StockQuantity;

        await _repository.Update(product);
        return new ProductModel.Response(product.Sku, product.InternalCode, product.Name, product.Description,
            product.CurrentUnitPrice, product.StockQuantity, product.Id);
    }


    public async Task<ProductModel.Response> DisableProduct(Guid id)
    {
        var product = await _repository.GetById<Product>(id);

        if (product == null) throw new EntityNotFoundException($"No se encontró el producto id:{id}");

        product.IsActive = false;

        await _repository.Update(product);

        return new ProductModel.Response(product.Sku, product.InternalCode, product.Name, product.Description,
            product.CurrentUnitPrice, product.StockQuantity, product.Id);

    }
}


