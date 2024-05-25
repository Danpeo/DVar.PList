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

    public async Task<IEnumerable<Product>> ListProductsByPricelist(Guid pricelistId)
    {
        /*var productIdsInPricelist = db.Pricelists
            .Include(pl => pl.ProductIds)
            .Where(pl => pl.Id == pricelistId)
            .SelectMany(pl => pl.ProductIds).AsEnumerable();
        
        var products = await db.Products.Where(p => productIdsInPricelist.Contains(p.Id)).ToListAsync();

        return products;*/
        return default;
    }
}