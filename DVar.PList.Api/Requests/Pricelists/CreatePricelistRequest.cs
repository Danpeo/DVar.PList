using DVar.PList.Domain.Entities;

namespace DVar.PList.Api.Requests.Pricelists;

public class CreatePricelistRequest
{
    public string Name { get; set; } = "";
    public List<CustomColumn> CustomColumns { get; set; } = new List<CustomColumn>();
}