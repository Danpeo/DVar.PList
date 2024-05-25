using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;

namespace DVar.PList.Infrastructure.RepositoryImplementations;

public class CustomColumnRepository(AppDbContext db) : ICustomColumnRepository
{
    public IEnumerable<CustomColumn> List(PaginationParams paginationParams) =>
        db.CustomColumns.Paginate(paginationParams);

    public IEnumerable<CustomColumn> ListForPricelist(Pricelist pricelist, PaginationParams paginationParams) =>
        pricelist.CustomColumns.Paginate(paginationParams);
}