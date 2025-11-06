using AutoMapper;
using DataLayer.Contracts;
using DataLayer.DTOs;
using DataLayer.Querys;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using DataLayer.Errors;

namespace Infrastructure.Repository
{
    public class QueryRepository(DefaultDbContext context, IMapper mapper) : IQueryRepository
    {
        public async Task<GetEstateByIdDto?> GetEstateById(int id)
        {
            var estate = await context.Estates.AsNoTracking()
                 .Include(e => e.Prices)
                 .Include(e => e.User)
                 .Include(e => e.Images)
                 .FirstOrDefaultAsync(e => e.Id == id);

            var result = mapper.Map<GetEstateByIdDto>(estate);
            return result;
        }

        public async Task<IList<GetEstatesDto>> GetAllEstates(GetEstatesQuery param)
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


            var result = await query.ProjectTo<GetEstatesDto>(mapper.ConfigurationProvider).ToListAsync();
            return result;

        }

        public async Task<IList<GetUserDto>> GetAllUsers(GetUserQuery param)
        {
            if (param.Page <= 0)
                throw new ArgumentException(UserError.PageSize);

            var query = context.Users.AsQueryable().AsNoTracking();



            if (!string.IsNullOrWhiteSpace(param.Search))
                query = query.Where(x => x.FullName.Contains(param.Search) ||
                                         x.Email.Contains(param.Search));

            query = query.OrderByDescending(x => x.Id);


            var skip = (param.Page - 1) * param.PageSize;
            query = query.Skip(skip).Take(param.PageSize);


            var result = await query
                .ProjectTo<GetUserDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
