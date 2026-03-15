using MediatR;
using ProductAPI.Domain;
namespace ProductAPI.Application.Products.Queries;

public sealed record GetAllProductsQuery() : IRequest<IReadOnlyList<Product>>;