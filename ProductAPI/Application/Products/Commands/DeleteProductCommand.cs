using MediatR;
namespace ProductAPI.Application.Products.Commands;

public sealed record DeleteProductCommand(int Id) : IRequest<bool>;
