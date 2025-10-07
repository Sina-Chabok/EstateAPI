using DataLayer.Contracts.Contracts;
using DataLayer.Errors;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EstateRepository : IEstateRepository
    {
        private readonly DefaultDbContext _context;

        public EstateRepository(DefaultDbContext context)
        {
            _context = context;
        }
        

        public async Task<Estate?> GetById(int id)
        {
            var estate = await _context.Estates.Where(e => e.Id == id).FirstOrDefaultAsync();
            return estate;
        }

        public async Task Insert(Estate estate)
        {
            await _context.Estates.AddAsync(estate);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Estate estate)
        {
             _context.Estates.Update(estate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Estate estate)
        {
            _context.Estates.Remove(estate);
           await _context.SaveChangesAsync();
        }
    }
}
