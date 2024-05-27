using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Infrastructure.RepositoryImplementations;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public Product Create(Product product) => db.Products.Add(product).Entity;

    public IEnumerable<Product> List(PaginationParams paginationParams)
    {
        var products = db.Products;
        return products.Paginate(paginationParams);
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        var product = await db.Products
            .Include(p => p.ProductCustomValues)
            .FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }
}