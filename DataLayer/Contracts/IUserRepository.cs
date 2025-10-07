using DataLayer.Models;

namespace DataLayer.Contracts.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<IList<User>> GetAll();
        Task Insert(User user);
        Task Update(User user);
        Task Delete(User user);


    }
}
