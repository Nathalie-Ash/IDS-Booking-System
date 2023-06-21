using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<CustomUser> CreateUser(CustomUser newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

 

        public async Task DeleteUser(CustomUser user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }



        public async Task<IEnumerable<CustomUser>> GetAllUsers()
        {
            return await _unitOfWork.Users
                .GetAllWithUserAsync();
        }

        public Task<IEnumerable<CustomUser>> GetUsersByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(CustomUser userToBeUpdated, CustomUser user)
        {
            throw new NotImplementedException();
        }

        Task<CustomUser> IUserService.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomUser>> GetAllWithUser()
        {
            throw new NotImplementedException();
        }
    }
}
