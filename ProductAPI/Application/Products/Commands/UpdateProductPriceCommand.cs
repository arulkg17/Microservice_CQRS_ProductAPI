using MediatR;
namespace ProductAPI.Application.Products.Commands;

public sealed record UpdateProductPriceCommand(int Id, decimal Price) : IRequest<bool>;
