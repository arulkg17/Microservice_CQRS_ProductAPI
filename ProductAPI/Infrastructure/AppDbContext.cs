using ProductAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Infrastructure;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; } = null!; 

}
