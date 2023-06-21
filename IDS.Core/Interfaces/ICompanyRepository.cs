using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface ICompanyRepository : IRepository<Company> 
    {

        Task<IEnumerable<Company>> GetAllWithCompaniesAsync();
        Task<Company> GetWithCompaniesByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id);
    }
}
