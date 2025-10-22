using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;

namespace Infrastructure.Mappings;

public class InsertEstateDtoToEstate : Profile
{
    public InsertEstateDtoToEstate()
    {
        CreateMap<CreatetEstateDto, Estate>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore()) // بعداً ست میشه
            .ForMember(dest => dest.Prices, opt => opt.MapFrom(src =>
                src.Prices.Select(p => new EstatePrice
                {
                    Amount = p.Amount,
                    PriceType = p.PriceType
                })));
    }
}