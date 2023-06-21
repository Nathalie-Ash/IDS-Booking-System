using AutoMapper;
using IDS.Core.Models;
using IDS.Services;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IDSBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleService.GetRoleById(id);
            return Ok(role);
        }


        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            var roleToBeUpdate = await _roleService.GetRoleById(id);

            if (roleToBeUpdate == null)
                return NotFound();

            await _roleService.UpdateRole(roleToBeUpdate, role);

            var updatedRole = await _roleService.GetRoleById(id);

            return Ok(updatedRole);
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role newrole)
        {
            var role = await _roleService.CreateRole(newrole);
            return Ok(role);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteRole(role);

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoleResource>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllWithRole();
                var roleResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<RoleResource>>(roles);

                return Ok(roleResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
