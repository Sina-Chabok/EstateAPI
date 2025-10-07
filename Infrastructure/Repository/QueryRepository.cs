using DataLayer.Contracts;
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
            return await _context.Estates.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Estate>> GetAll()
        {
            return await _context.Estates.AsNoTracking().ToListAsync();
        }

    }
}
