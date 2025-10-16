using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;

namespace Infrastructure.Mappings
{
    public class EstatesToGetEstatesDto : Profile
    {
        public EstatesToGetEstatesDto()
        {
            CreateMap<Estate, GetEstatesDto>();
            CreateMap<Estate, GetEstateByIdDto>();
        }
    }
}
