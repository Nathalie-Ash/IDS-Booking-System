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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(IDSDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Room>> GetAllWithRoomAsync()
        {
            return await IDSDbContext.Rooms
                //.Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<Room> GetWithRoomByIdAsync(int id)
        {
            return await IDSDbContext.Rooms
                //.Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Room>> GetAllWithRoomByRoomIdAsync(int roomId)
        {
            return await IDSDbContext.Rooms
                //.Include(m => m.Company)
                //   .Where(m => m.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<IEnumerable<Room>> GetAllWithRoomsAsync()
        {
            throw new NotImplementedException();
        }

 

        public Task<IEnumerable<Room>> GetAllWithRoomsByRoomIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Role> IRoomRepository.GetWithRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSDbContext IDSDbContext
        {
            get { return Context as IDSDbContext; }
        }
    }
}
