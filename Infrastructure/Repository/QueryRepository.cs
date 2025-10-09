using DataLayer.Contracts;
using DataLayer.Errors;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly DefaultDbContext _context;

        public QueryRepository(DefaultDbContext context)
        {
            _context = context;
        }


        public async Task<Estate?> GetById(int id)
        {
           var estate = await _context.Estates.AsNoTracking().Include(e => e.Prices).Include(e => e.User)
                .Include(e => e.Images)
                .FirstOrDefaultAsync(e=>e.Id == id);
           if (estate is null)
               throw new ArgumentNullException(EstateError.EstateNotFound);

           return estate;

        }       

        public async Task<IList<Estate>> GetAll()
        {
            return await _context.Estates.AsNoTracking().ToListAsync();
        }

    }
}
