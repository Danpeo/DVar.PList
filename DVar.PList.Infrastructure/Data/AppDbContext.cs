using DVar.PList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Infrastructure.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pricelist> Pricelists { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomColumn> CustomColumns { get; set; }
    public DbSet<ProductCustomValue> ProductCustomValues { get; set; }
}