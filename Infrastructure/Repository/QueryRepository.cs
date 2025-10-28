using AutoMapper;
using DataLayer.Contracts;
using DataLayer.DTOs;
using DataLayer.Querys;
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

        public async Task<IList<GetEstatesDto>> GetAll(GetEstatesQuery param)
        {
            var query = context.Estates.AsQueryable().AsNoTracking();


            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(x => x.Title.Contains(param.Search) || 
                                         x.Province.Contains(param.Search) ||
                                         x.City.Contains(param.Search));

            if (param.EstateType != null)
                query = query.Where(x => x.EstateType == param.EstateType);

            if (param.DocumentType != null)
                query = query.Where(x => x.DocumentType == param.DocumentType);

            query = query.OrderByDescending(x => x.Id);

            var estates = await query.ToListAsync();

            var result = mapper.Map<IList<GetEstatesDto>>(estates);
            return result;

        }
    }
}
