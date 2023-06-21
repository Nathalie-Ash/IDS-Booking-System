using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDSDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Role>> GetAllWithRoleAsync()
        {
            return await IDSDbContext.Roles
                //.Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<Role> GetWithRoleByIdAsync(int id)
        {
            return await IDSDbContext.Roles
                //.Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Role>> GetAllWithRoleByRoleIdAsync(int roleId)
        {
            return await IDSDbContext.Roles
                //.Include(m => m.Company)
                //   .Where(m => m.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<IEnumerable<Role>> GetAllWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetWithRolesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllWithRolesByRoleIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        private IDSDbContext IDSDbContext
        {
            get { return Context as IDSDbContext; }
        }
    }
}
