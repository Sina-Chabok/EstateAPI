using DataLayer.Contracts.Contracts;
using DataLayer.Enums;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EstateRepository(DefaultDbContext context) : IEstateRepository
    {
        public async Task<Estate?> GetById(int id)
        {
            var estate = await context.Estates
                .Include(e => e.Prices).FirstOrDefaultAsync(e => e.Id == id);
            return estate;
        }

        public async Task Insert(Estate estate)
        {
            await context.Estates.AddAsync(estate);
            await context.SaveChangesAsync();

        }

        public async Task Update(Estate estate)
        {
            context.Estates.Update(estate);
            await context.SaveChangesAsync();

        }

        public async Task Delete(Estate estate)
        {
            context.Estates.Remove(estate);
            await context.SaveChangesAsync();

        }

        public async Task InsertPrice(EstatePrice price)
        {
            await context.EstatePrices.AddAsync(price);
            await context.SaveChangesAsync();

        }

        public async Task UpdatePrice(EstatePrice price)
        {
            context.EstatePrices.Update(price);
            await context.SaveChangesAsync();

        }

        public async Task DeletePrice(EstatePrice price)
        {
            context.EstatePrices.Remove(price);
            await context.SaveChangesAsync();

        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
