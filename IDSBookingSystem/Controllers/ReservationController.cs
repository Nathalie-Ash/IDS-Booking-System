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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservations();
            return Ok(reservations);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            return Ok(reservation);
        }


        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            var reservationToBeUpdate = await _reservationService.GetReservationById(id);

            if (reservationToBeUpdate == null)
                return NotFound();

            await _reservationService.UpdateReservation(reservationToBeUpdate, reservation);

            var updatedReservation = await _reservationService.GetReservationById(id);

            return Ok(updatedReservation);
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation newreservation)
        {
            var reservation = await _reservationService.CreateReservation(newreservation);
            return Ok(reservation);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservation(reservation);

            return NoContent();
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReservationResource>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllWithReservation();
                var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);

                return Ok(reservationResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
