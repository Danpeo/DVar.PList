using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;

namespace DVar.PList.Domain.RepositoryInterfaces;

public interface IPricelistRepository
{
    void Create(Pricelist pricelist);
    IEnumerable<Pricelist> List(PaginationParams paginationParams);
    Task<Pricelist?> GetAsync(Guid id);
    Task UpdateAsync(Guid id, Pricelist pricelist);
}