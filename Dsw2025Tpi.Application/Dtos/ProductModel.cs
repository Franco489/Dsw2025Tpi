namespace Dsw2025Tpi.Application.Dtos;

public record ProductModel
{
    public record Request(string Sku, string InternalCode, string Name, string Description, decimal Price,
        int StockQuantity);

    public record Response(string? Sku, string? InternalCode, string? Name, string? Description, decimal Price,
            int StockQuantity, Guid Id);
}

