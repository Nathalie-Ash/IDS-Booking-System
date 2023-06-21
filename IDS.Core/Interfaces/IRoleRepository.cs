using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {

        Task<IEnumerable<Role>> GetAllWithRoleAsync();
        Task<Role> GetWithRolesByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllWithRolesByRoleIdAsync(int id);
    }
}
