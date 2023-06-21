using AutoMapper;
using IDS.Core.Models;
using IDS.Services;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Mvc;

namespace IDSBookingSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomUser>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }




        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, CustomUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var userToBeUpdate = await _userService.GetUserById(id);

            if (userToBeUpdate == null)
                return NotFound();

            await _userService.UpdateUser(userToBeUpdate, user);

            var updatedUser = await _userService.GetUserById(id);

            return Ok(updatedUser);
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomUser>> PostUser(CustomUser newuser)
        {
            var user = await _userService.CreateUser(newuser);
            return Ok(user);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(user);

            return NoContent();
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllWithUser();
                var userResources = _mapper.Map<IEnumerable<CustomUser>, IEnumerable<RoleResource>>(users);

                return Ok(userResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
