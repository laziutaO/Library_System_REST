using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicLayer.Interfaces;

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
            
            return Ok();
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
            return Ok(reservation);
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
            return Ok(reservations);
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
            return Ok(reservations);
        }

        //to finish
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody]ReservationCreateRequest reservRequest)
        {
            bool ableToReserve = await _reservationService.CheckIfCanReserve(reservRequest.UserId, reservRequest.BookCopyId);
            if (!ableToReserve)
                return Ok("Cannot make reservation because either user is blocked or there are no available books");
            var reservation =  await _reservationService.CreateReservationAsync(reservRequest);
            return Ok(reservRequest);
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

            return Ok(reservUpdateRequest);

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
            return Ok(reservation);
        }

    }
}
