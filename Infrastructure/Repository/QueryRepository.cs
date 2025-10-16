using AutoMapper;
using DataLayer.Contracts;
using DataLayer.DTOs;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class QueryRepository(DefaultDbContext context, IMapper mapper) : IQueryRepository
    {
        public async Task<GetEstateByIdDto?> GetById(int id)
        {
            var estate = await context.Estates.AsNoTracking()
                 .Include(e => e.Prices)
                 .Include(e => e.User)
                 .Include(e => e.Images)
                 .FirstOrDefaultAsync(e => e.Id == id);
            
            var result = mapper.Map<GetEstateByIdDto>(estate);
            return result;
        }

        public async Task<IList<GetEstatesDto>> GetAll()
        {
            var estates = await context.Estates.AsNoTracking().ToListAsync();

            var result = mapper.Map<IList<GetEstatesDto>>(estates);
            return result;

        }

    }
}
