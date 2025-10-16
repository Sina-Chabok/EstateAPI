using DataLayer.Enums;
using DataLayer.Extensions;

namespace DataLayer.DTOs;

public class GetPricesDto
{
    public int Id { get; set; }

    public PriceTypeEnum PriceType { get; set; }

    public string PriceName => PriceType.GetDisplayName();

    public decimal Amount { get; set; }
}