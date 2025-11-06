using DataLayer.DTOs;
using DataLayer.Models;

namespace DataLayer.Contracts.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);
        Task<IList<User>> GetAll();
        Task InsertAsync(User user);
        Task Update(User user);
        Task Delete(User user);


    }
}
