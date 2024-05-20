using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;

namespace DVar.PList.Domain.RepositoryInterfaces;

public interface IPricelistRepository
{
    void Create(Pricelist pricelist);
    Task<IEnumerable<Pricelist>> ListAsync(PaginationParams paginationParams);
}