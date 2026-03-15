using Microsoft.EntityFrameworkCore;
using ProductAPI.Infrastructure;
using System.Reflection;
using MediatR;
using ProductAPI.Application.Products.Commands;
using ProductAPI.Application.Products.Queries;
using ProductAPI.Application.Products.Contracts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("ProductDb");
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Queried (read)
app.MapGet("/api/products", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(result);
});

app.MapGet("/api/products/{id:int}", async (int id, IMediator mediator)=>{
    var result = await mediator.Send(new GetProductByIdQuery(id));
    return result is null ? Results.NotFound() : Results.Ok(result);
});

//Command (write)
app.MapPost("/api/AddProduct", async (CreateProductRequest request, IMediator mediator) =>
{
    var id = await mediator.Send(new CreateProductCommand(request.name, request.price));
    return Results.Created($"/api/products/{id}", new { id });
});

app.MapPut("/api/products/{id:int}/price", async (int id, UpdateProductPriceRequest request, IMediator mediator) =>
{
    var success = await mediator.Send(new UpdateProductPriceCommand(id, request.newPrice));
    return success ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/api/products", async (int id, IMediator mediator) => {
    var success = await mediator.Send(new DeleteProductCommand(id));
    return success ? Results.NoContent() : Results.NotFound();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

