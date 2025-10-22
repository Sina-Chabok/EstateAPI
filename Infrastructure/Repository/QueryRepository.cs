using System.Security.Cryptography.X509Certificates;
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

            if (param.Title != null)
                query = query.Where(x => x.Title.Contains(param.Title));

            if (param.Province != null)
                query = query.Where(x => x.Province.Contains(param.Province));

            if (param.EstateType != null)
                query = query.Where(x => x.EstateType == param.EstateType);

            if (param.EstateType != null)
                query = query.Where(x => x.City == param.City);

            if (param.DocumentType != null)
                query = query.Where(x => x.DocumentType == param.DocumentType);
            
            

            var estates = await query.ToListAsync();

            var result = mapper.Map<IList<GetEstatesDto>>(estates);
            return result;

        }

    }
}
