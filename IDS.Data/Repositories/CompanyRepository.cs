using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDSDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithCompanyAsync()
        {
            return await IDSDbContext.Companies
                //.Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<Company> GetWithCompanyByIdAsync(int id)
        {
            return await IDSDbContext.Companies
                //.Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Company>> GetAllWithCompanyByCompanyIdAsync(int companyId)
        {
            return await IDSDbContext.Companies
                //.Include(m => m.Company)
                //   .Where(m => m.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<IEnumerable<Company>> GetAllWithCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetWithCompaniesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSDbContext IDSDbContext
        {
            get { return Context as IDSDbContext; }
        }
    }
}
