using DataLayer.Contracts.Contracts;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DefaultDbContext _context;

        public UserRepository(DefaultDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetById(int id)
        {
           return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
           
        }

        //ToDo(Sina):Add Filters
        public async Task<IList<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Insert(User user)
        {
             _context.Users.Add(user);
             await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
