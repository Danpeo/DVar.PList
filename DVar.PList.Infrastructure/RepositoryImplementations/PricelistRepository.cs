using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Infrastructure.RepositoryImplementations;

public class PricelistRepository(AppDbContext db) : IPricelistRepository
{
    public void Create(Pricelist pricelist) => 
        db.Pricelists.Add(pricelist);

    public IEnumerable<Pricelist> List(PaginationParams paginationParams) => 
        db.Pricelists.Paginate(paginationParams);

    public async Task<Pricelist?> GetAsync(Guid id)
    {
        return await db.Pricelists
            .AsSplitQuery()
            .Include(p => p.Products)
            .ThenInclude(p => p.ProductCustomValues)
            .Include(p => p.CustomColumns)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Guid id, Pricelist pricelist)
    {
        /*var p = await db.Pricelists.FirstOrDefaultAsync(p => p.Id == id);
        if (p != null)
        {
            p.Products = pricelist.Products;
        }*/
        db.Pricelists.Update(pricelist);
    }
}