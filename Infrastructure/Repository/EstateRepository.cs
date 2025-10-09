using DataLayer.Contracts.Contracts;
using DataLayer.Enums;
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
            var estate = await _context.Estates
                .Include(e => e.Prices).FirstOrDefaultAsync(e => e.Id == id);
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

        public async Task InsertPrice(EstatePrice price)
        {
            await _context.EstatePrices.AddAsync(price);
            await _context.SaveChangesAsync();

        }

        public async Task UpdatePrice(EstatePrice price)
        {
            _context.EstatePrices.Update(price);
            await _context.SaveChangesAsync();

        }

        public async Task DeletePrice(EstatePrice price)
        {
            _context.EstatePrices.Remove(price);
            await _context.SaveChangesAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
