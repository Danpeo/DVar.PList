using Danilvar.Entity;

namespace DVar.PList.Domain.Entities;

public class ProductCustomValue : Entity
{
    public Product Product { get; set; }
    public CustomColumn CustomColumn { get; set; }
    public string Value { get; set; }
}