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
    public class UserRepository : Repository<CustomUser>, IUserRepository
    {
        public UserRepository(IDSDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<CustomUser>> GetAllWithUserAsync()
        {
            return await IDSDbContext.Users
                //.Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<CustomUser> GetWithUserByIdAsync(int id)
        {
            return await IDSDbContext.Users
                //.Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<CustomUser>> GetAllWithUserByUserIdAsync(int userId)
        {
            return await IDSDbContext.Users
                //.Include(m => m.Company)
                //   .Where(m => m.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<IEnumerable<CustomUser>> GetAllWithUsersAsync()
        {
            throw new NotImplementedException();
        }



        public Task<IEnumerable<CustomUser>> GetAllWithUsersByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    
        

        private IDSDbContext IDSDbContext
        {
            get { return Context as IDSDbContext; }
        }
    }
}
