using DataLayer.DTOs;
using DataLayer.Models;

namespace DataLayer.Contracts
{
    public interface IQueryRepository
    {
        Task<GetEstateByIdDto?> GetById(int id);
        Task<IList<GetEstatesDto>> GetAll();
    }
}
