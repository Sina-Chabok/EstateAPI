using DataLayer.DTOs;
using DataLayer.Querys;

namespace DataLayer.Contracts
{
    public interface IQueryRepository
    {
        Task<GetEstateByIdDto?> GetEstateById(int id);
        Task<IList<GetEstatesDto>> GetAllEstates(GetEstatesQuery param);

        Task<IList<GetUserDto>> GetAllUsers(GetUserQuery param);
    }
}
