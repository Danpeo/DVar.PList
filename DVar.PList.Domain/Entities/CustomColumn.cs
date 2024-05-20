using Danilvar.Entity;
using DVar.PList.Domain.Enums;

namespace DVar.PList.Domain.Entities;

public class CustomColumn : Entity
{
    public string Name { get; set; } = "";
    public DataType DataType { get; set; }
}