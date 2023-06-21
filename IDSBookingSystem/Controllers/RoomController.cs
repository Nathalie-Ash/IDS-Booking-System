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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _roomService.GetRoomById(id);
            return Ok(room);
        }


        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var roomToBeUpdate = await _roomService.GetRoomById(id);

            if (roomToBeUpdate == null)
                return NotFound();

            await _roomService.UpdateRoom(roomToBeUpdate, room);

            var updatedRoom = await _roomService.GetRoomById(id);

            return Ok(updatedRoom);
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room newroom)
        {
            var room = await _roomService.CreateRoom(newroom);
            return Ok(room);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomService.DeleteRoom(room);

            return NoContent();
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoomResource>>> GetAllRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllWithRoom();
                var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoleResource>>(rooms);

                return Ok(roomResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }
    }
}
