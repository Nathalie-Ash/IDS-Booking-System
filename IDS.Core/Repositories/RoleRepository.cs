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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDSbookingSystemContext role)
            : base(role)
        { }

        public async Task<IEnumerable<Role>> GetAllWithRolesAsync()
        {
            return await MyDbContext.Roles

                .ToListAsync();
        }

        public Task<Role> GetWithRolesByIdAsync(int id)
        {
            return MyDbContext.Roles
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Role>> GetAllWithRolesByRoleIdAsync(int id)
        {
            throw new NotImplementedException();
        }

     
        public Task<IEnumerable<Role>> GetAllWithRoleAsync()
        {
            throw new NotImplementedException();
        }

        private IDSbookingSystemContext MyDbContext
        {
            get { return Context as IDSbookingSystemContext; }
        }
    }
}
