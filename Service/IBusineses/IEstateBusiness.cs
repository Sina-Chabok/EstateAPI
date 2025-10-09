using System.Net.Mime;
using Application.DTOs;
using DataLayer.Models;

namespace Service.IBusineses
{
    public interface IEstateBusiness
    {
      
        Task Insert(Estate estate);
        Task Update(UpdateEstateDto dto);
        Task Delete(int id);

    }
}
