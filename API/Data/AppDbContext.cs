using CardapioOnline.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CardapioOnline.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
}