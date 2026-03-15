using MediatR;

namespace ProductAPI.Application.Products.Commands;

public sealed record CreateProductCommand(string name, decimal price):IRequest<int>;
