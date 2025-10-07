using DataLayer.Models;

namespace Service.IBusineses
{
    public interface IEstateBusiness
    {
      
        Task Insert(Estate estate);    

        Task Update(Estate estate);

        Task Delete(int id);

    }
}
