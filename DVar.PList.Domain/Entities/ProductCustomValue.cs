using Danilvar.Entity;

namespace DVar.PList.Domain.Entities;

public class ProductCustomValue : Entity
{
    public Guid CustomColumnId { get; set; }
    public string Value { get; set; }
}