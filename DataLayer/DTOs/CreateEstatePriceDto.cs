using DataLayer.Enums;

namespace DataLayer.DTOs;

public class CreateEstatePriceDto
{
    public PriceTypeEnum PriceType { get; set; }
    public decimal Amount { get; set; }
}