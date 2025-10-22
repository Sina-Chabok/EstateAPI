using DataLayer.DTOs;
using DataLayer.Models;

namespace Service.IBusineses
{
    public interface IEstateBusiness    
    {
      
        Task Insert(CreatetEstateDto estate);
        Task Update(UpdateEstateDto dto);
        Task Delete(int id);

    }
}
