using Danilvar.Entity;

namespace DVar.PList.Domain.Entities;

public class Pricelist : Entity
{
    public string Name { get; set; } = "";
    public ICollection<CustomColumn> CustomColumns { get; set; } = new List<CustomColumn>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}