using Danilvar.Entity;

namespace DVar.PriceList.Domain.Entities;

public class PriceList : Entity
{
    public string Name { get; set; } = "";
    public ICollection<Product> Products { get; set; } = new List<Product>();
}