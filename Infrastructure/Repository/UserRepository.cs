using DataLayer.Contracts.Contracts;
using DataLayer.DTOs;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository(DefaultDbContext context) : IUserRepository
    {
        public async Task<User?> GetById(int id)
        {
           return await context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<User?> GetByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        //ToDo(Sina):Add Filters
        public async Task<IList<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task InsertAsync(User user)
        {
             context.Users.Add(user);
             await context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
