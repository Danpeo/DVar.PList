using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;

namespace DVar.PList.Domain.RepositoryInterfaces;

public interface ICustomColumnRepository
{
    IEnumerable<CustomColumn> List(PaginationParams paginationParams);
    IEnumerable<CustomColumn> ListForPricelist(Pricelist pricelist, PaginationParams paginationParams);
}