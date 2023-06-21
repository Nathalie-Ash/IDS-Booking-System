using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<CustomUser>> GetAllUsers
            ();
        Task<CustomUser> GetUserById(int id);
        Task<IEnumerable<CustomUser>> GetUsersByUserId(int id);
        Task<CustomUser> CreateUser(CustomUser newUser);
        Task UpdateUser(CustomUser userToBeUpdated, CustomUser user);
        Task DeleteUser(CustomUser user);
        Task<IEnumerable<CustomUser>> GetAllWithUser();
    }
}
