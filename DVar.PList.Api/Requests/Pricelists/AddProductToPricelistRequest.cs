using DVar.PList.Domain.Entities;

namespace DVar.PList.Api.Requests.Pricelists;

public record AddProductToPricelistRequest(
    string ProductName,
    string Code,
    IEnumerable<ProductCustomValue> ProductCustomValues);