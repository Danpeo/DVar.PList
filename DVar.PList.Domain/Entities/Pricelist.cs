using Danilvar.Entity;

namespace DVar.PList.Domain.Entities;

public class Pricelist : Entity
{
    public string PricelistName { get; set; } = "";
    public List<CustomColumn> CustomColumns { get; set; } = [];
    public List<Product> Products { get; set; } = [];
}