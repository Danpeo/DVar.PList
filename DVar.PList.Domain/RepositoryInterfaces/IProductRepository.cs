using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;

namespace DVar.PList.Domain.RepositoryInterfaces;

public interface IProductRepository
{
    Product Create(Product product);
    IEnumerable<Product> List(PaginationParams paginationParams);
    Task<IEnumerable<Product>> ListProductsByPricelist(Guid pricelistId);
}