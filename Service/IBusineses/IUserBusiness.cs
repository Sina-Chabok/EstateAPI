using DataLayer.DTOs;
using DataLayer.Models;

namespace Service.IBusineses
{
    public interface IUserBusiness
    {
        Task Insert(CreateUserDto dto);

        Task<string?> Login(LoginDto dto);
        Task Delete(int id);
    }
}
