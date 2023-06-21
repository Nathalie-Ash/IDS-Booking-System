using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {

        Task<IEnumerable<Room>> GetAllWithRoomAsync();
        Task<Role> GetWithRoomByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllWithRoomsByRoomIdAsync(int id);
    }
}
