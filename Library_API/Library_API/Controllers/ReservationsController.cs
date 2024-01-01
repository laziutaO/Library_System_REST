using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReservation([FromRoute] Guid id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation( ReservationAddDto reservRequest)
        {
            await _reservationService.CreateReservationAsync(reservRequest);

            return Ok(reservRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, Reservation reservUpdateRequest)
        {
            var reservation = await _reservationService.UpdateReservationAsync(id, reservUpdateRequest);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);

        }
    }
}
