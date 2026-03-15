using ProductAPI.Domain;
using ProductAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Products.Queries;

namespace ProductAPI.Application.Products.Handlers;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<Product>> { 
    private readonly AppDbContext _db;

    public GetAllProductsQueryHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _db.Products
               .AsNoTracking()
               .OrderBy(x => x.Id)
               .ToListAsync(cancellationToken);
    }        
 }