using DataLayer.Errors;
using DataLayer.Models;

namespace DataLayer.Contracts.Contracts
{
    public interface IEstateRepository
    {

        Task<Estate?> GetById(int id);
      
        Task Insert(Estate estate);
        Task Update(Estate estate);
        Task Delete(Estate estate);
    }
}
