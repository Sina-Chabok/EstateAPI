using AutoMapper;
using DataLayer.DTOs;
using Estate.Api.VMs.Command;

namespace Estate.Api.Mappings
{
    public class UpdateEstateVmToUpdateestateDto : Profile
    {
        public UpdateEstateVmToUpdateestateDto()
        {
            CreateMap<UpdateEstateVm,UpdateEstateDto>()
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src =>
                    src.Prices.Select(p => new UpdateEstatePriceDto()
                    {
                        Amount = p.Amount,
                        PriceType = p.PriceType
                    })));
        }
    }
}
