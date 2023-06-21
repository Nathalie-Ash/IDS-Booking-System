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
    public class UserRepository : Repository<CustomUser>, IUserRepository
    {
        public UserRepository(IDSbookingSystemContext user)
            : base(user)
        { }

        public async Task<IEnumerable<CustomUser>> GetAllWithUserAsync()
        {
            return await MyDbContext.Users

                .ToListAsync();
        }

        public Task<CustomUser> GetWithUsersByIdAsync(int id)
        {
            return MyDbContext.Users
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<CustomUser>> GetAllWithUsersByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> GetWithUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSbookingSystemContext MyDbContext
        {
            get { return Context as IDSbookingSystemContext; }
        }
    }
}
