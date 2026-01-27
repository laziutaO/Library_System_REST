using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReservationsController:Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            if (reservations == null )
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReservationGetRequest>>()
            {
                ["reservations"] = reservations
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReservation([FromRoute] Guid id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            if(reservation == null)   
            { 
                return NotFound(); 
            }
            var output = new Dictionary<string, ReservationGetRequest>()
            {
                ["reservation"] = reservation
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetReservationsByUser([FromQuery] Guid userId)
        {
            var reservations = await _reservationService.GetReservationsByUserAsync(userId);
            if(reservations == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReservationGetRequest>>()
            {
                ["reservations"] = reservations
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("book")]
        public async Task<IActionResult> GetReservationsByBook([FromQuery]Guid bookId)
        {
            var reservations = await _reservationService.GetReservationsByBookAsync(bookId);
            if (reservations == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReservationGetRequest>>()
            {
                ["reservations"] = reservations
            };
            return Ok(output);
        }

        //to finish
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody]ReservationCreateRequest reservRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                return Unauthorized();

            var userGuid = Guid.Parse(userId);
            bool ableToReserve = true;
            if (!ableToReserve)
                return Ok("Cannot make reservation because either user is blocked or there are no available books");
            var reservation =  await _reservationService.CreateReservationAsync(reservRequest, userGuid);
            var output = new Dictionary<string, ReservationGetRequest>()
            {
                ["reservations"] = reservation
            };
            return CreatedAtAction(nameof(AddReservation), output);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, [FromBody]ReservationUpdateRequest reservUpdateRequest)
        {
            var reservation = await _reservationService.UpdateReservationAsync(id, reservUpdateRequest);

            if (reservation == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] Guid id)
        {
            var reservation = await _reservationService.DeleteReservationAsync(id);
            if(reservation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
