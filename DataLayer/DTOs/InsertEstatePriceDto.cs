using DataLayer.Enums;

namespace DataLayer.DTOs;

public class InsertEstatePriceDto
{
    public PriceTypeEnum PriceType { get; set; }
    public decimal Amount { get; set; }
}