using Danilvar.Entity;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Domain.Entities;

[Owned]
public class Product : Entity
{
    public string ProductName { get; set; } = "";
    public string Code { get; set; } = "";
    public ICollection<ProductCustomValue> ProductCustomValues { get; set; } = new List<ProductCustomValue>();
}