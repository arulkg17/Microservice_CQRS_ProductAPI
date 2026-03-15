using ProductAPI.Application.Products.Queries;
using ProductAPI.Domain;
using ProductAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Application.Products.Handlers;

public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly AppDbContext _db;
    public GetProductByIdQueryHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }

}
