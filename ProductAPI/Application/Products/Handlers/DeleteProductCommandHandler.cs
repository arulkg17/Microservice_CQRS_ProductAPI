using MediatR;
using ProductAPI.Application.Products.Commands;
using ProductAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Application.Products.Handlers;

public sealed class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteProductCommandHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products
                    .FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null) return false;

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        return true;

    }
}
