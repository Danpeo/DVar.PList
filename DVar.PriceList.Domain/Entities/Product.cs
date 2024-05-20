using Danilvar.Entity;
using DVar.PriceList.Domain.ValueObjects;

namespace DVar.PriceList.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public ICollection<ProductColumn> ProductColumns { get; set; } = new List<ProductColumn>();
}