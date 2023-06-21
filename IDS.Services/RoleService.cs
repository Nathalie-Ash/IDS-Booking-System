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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Role> CreateRole(Role newRole)
        {
            await _unitOfWork.Roles.AddAsync(newRole);
            await _unitOfWork.CommitAsync();
            return newRole;
        }

      

        public async Task DeleteRole(Role role)
        {
            _unitOfWork.Roles.Remove(role);
            await _unitOfWork.CommitAsync();
        }



        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _unitOfWork.Roles
                .GetAllWithRoleAsync();
        }

        public Task<IEnumerable<Role>> GetRolesByRoleId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRole(Role roleToBeUpdated, Role role)
        {
            throw new NotImplementedException();
        }

        Task<Role> IRoleService.GetRoleById(int id)
        {
            throw new NotImplementedException();
        }


        Task<Role> IRoleService.CreateRole(Role newRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithRole()
        {
            throw new NotImplementedException();
        }
    }
}
