using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDSbookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithCompaniesAsync()
        {
            return await MyDbContext.Companies
                
                .ToListAsync();
        }

        public Task<Company> GetWithCompaniesByIdAsync(int id)
        {
            return MyDbContext.Companies
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSbookingSystemContext MyDbContext
        {
            get { return Context as IDSbookingSystemContext; }
        }
    }
}
