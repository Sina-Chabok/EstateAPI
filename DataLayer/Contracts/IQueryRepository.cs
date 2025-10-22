using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Querys;

namespace DataLayer.Contracts
{
    public interface IQueryRepository
    {
        Task<GetEstateByIdDto?> GetById(int id);
        Task<IList<GetEstatesDto>> GetAll(GetEstatesQuery param);
    }
}
