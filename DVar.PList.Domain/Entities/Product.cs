using Danilvar.Entity;

namespace DVar.PList.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public ICollection<ProductCustomValue> ProductCustomValues { get; set; } = new List<ProductCustomValue>();
}