using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface IQueryRepository
    {
        Task<Estate?> GetById(int id);
        Task<IList<Estate>> GetAll();
    }
}
