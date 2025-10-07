using System.Security.AccessControl;
using DataLayer.Contracts.Contracts;
using DataLayer.Models;
using Service.IBusineses;

namespace Service.Busineses
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IList<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Insert(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task Delete(User user)
        {
            await _userRepository.Delete(user);
        }

        private void ValidateUser(User user)
        {

        }
    }
}
