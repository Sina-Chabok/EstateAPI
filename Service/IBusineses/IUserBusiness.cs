using DataLayer.Models;

namespace Service.IBusineses
{
    public interface IUserBusiness
    {
        Task<IList<User>> GetAll();

        Task<User?> GetById(int id);

        Task Insert(User user);

        Task Update(User user);

        Task Delete(User user);

    }
}
