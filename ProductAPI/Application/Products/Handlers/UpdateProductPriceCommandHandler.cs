using ProductAPI.Application.Products.Commands;
using ProductAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Application.Products.Handlers;
public sealed class UpdateProductPriceCommandHandler
    : IRequestHandler<UpdateProductPriceCommand, bool>
{
    private readonly AppDbContext _db;

    public UpdateProductPriceCommandHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null)
            return false;

        product.Price = request.Price;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
