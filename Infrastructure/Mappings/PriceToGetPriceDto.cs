using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;

namespace Infrastructure.Mappings
{
    public class PriceToGetPriceDto : Profile
    {
        public PriceToGetPriceDto()
        {
            CreateMap<EstatePrice, GetPricesDto>();
        }
    }
}
