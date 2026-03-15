using ProductAPI.Domain;
using MediatR;
namespace ProductAPI.Application.Products.Queries;

public sealed record GetProductByIdQuery(int Id) : IRequest<Product?>;