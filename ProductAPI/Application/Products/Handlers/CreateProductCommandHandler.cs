using ProductAPI.Application.Products.Commands;
using ProductAPI.Domain;
using ProductAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Application.Products.Handlers;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly AppDbContext _db;

    public CreateProductCommandHandler(AppDbContext db)
    { 
        _db = db;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.name,
            Price = request.price,
        };

        _db.Products.Add(product);
         await _db.SaveChangesAsync();
        return product.Id;
        ;
    }

}
