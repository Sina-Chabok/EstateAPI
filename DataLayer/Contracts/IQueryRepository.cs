using DataLayer.Models;

namespace DataLayer.Contracts
{
    public interface IQueryRepository
    {
        Task<Estate?> GetById(int id);
        Task<IList<Estate>> GetAll();
    }
}
