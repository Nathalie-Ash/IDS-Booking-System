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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(IDSbookingSystemContext room)
            : base(room)
        { }

        public async Task<IEnumerable<Room>> GetAllWithRoomAsync()
        {
            return await MyDbContext.Rooms

                .ToListAsync();
        }

        public Task<Room> GetWithRoomsByIdAsync(int id)
        {
            return MyDbContext.Rooms
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Room>> GetAllWithRoomsByRoomIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetWithRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSbookingSystemContext MyDbContext
        {
            get { return Context as IDSbookingSystemContext; }
        }
    }
}
