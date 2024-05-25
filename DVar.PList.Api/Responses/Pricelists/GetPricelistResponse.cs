using DVar.PList.Domain.Entities;

namespace DVar.PList.Api.Responses.Pricelists;

public record GetPricelistResponse(
    Guid Id,
    string PricelistName,
    IEnumerable<CustomColumn> CustomColumns,
    IEnumerable<Product> Products);