using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IUserRepository : IRepository<CustomUser>
    {

        Task<IEnumerable<CustomUser>> GetAllWithUserAsync();
        Task<CustomUser> GetWithUserByIdAsync(int id);
        Task<IEnumerable<CustomUser>> GetAllWithUsersByUserIdAsync(int id);
    }

}