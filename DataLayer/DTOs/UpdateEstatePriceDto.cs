using DataLayer.Enums;

namespace DataLayer.DTOs;

public class UpdateEstatePriceDto
{
    public PriceTypeEnum PriceType { get; set; }
    public decimal Amount { get; set; }
}