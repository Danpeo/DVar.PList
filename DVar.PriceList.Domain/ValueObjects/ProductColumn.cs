using DVar.PriceList.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DVar.PriceList.Domain.ValueObjects;

[Owned]
public class ProductColumn
{
    public string Name { get; set; } = "";
    public DataType DataType { get; set; }
}