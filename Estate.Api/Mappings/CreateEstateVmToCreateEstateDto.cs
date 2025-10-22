using AutoMapper;
using DataLayer.DTOs;
using Estate.Api.VMs.Command;

namespace Estate.Api.Mappings
{
    public class CreateEstateVmToCreateEstateDto: Profile
    {
        public CreateEstateVmToCreateEstateDto()
        {
            CreateMap<CreateEstateVm, CreatetEstateDto>()
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src =>
                    src.Prices.Select(p => new CreateEstatePriceDto()
                    {
                        Amount = p.Amount,
                        PriceType = p.PriceType
                    })));
        }
    }
}
