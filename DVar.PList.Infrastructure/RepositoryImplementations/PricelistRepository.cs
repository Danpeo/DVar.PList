using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Infrastructure.RepositoryImplementations;

public class PricelistRepository(AppDbContext db) : IPricelistRepository
{
    public void Create(Pricelist pricelist) => db.Pricelists.Add(pricelist);

    public async Task<IEnumerable<Pricelist>> ListAsync(PaginationParams paginationParams)
    {
        var pricelists = await db.Pricelists.ToListAsync();
        return pricelists.Paginate(paginationParams);
    }
}