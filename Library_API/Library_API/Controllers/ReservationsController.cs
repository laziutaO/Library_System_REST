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
        private readonly IBookService<Ebook> _bookService;
        private readonly IUserService _userService;
        public ReservationsController(IReservationService reservationService, IBookService<Ebook> bookService, IUserService userService)
        {
            _reservationService = reservationService;
            _bookService = bookService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            if (reservations == null )
            {
                return NotFound();
            }
            List<ReservationGetRequest> reservation_output = new List<ReservationGetRequest>();
            foreach(var reservation in reservations)
            {
                var bookinfo = await _bookService.GetBookAsync(reservation.BookCopyId);
                var userinfo = await _userService.GetUserAsync(reservation.UserId);
                var reservation_info = new ReservationGetRequest(
                    new (
                        userinfo.FirstName,
                        userinfo.LastName
                    ),
                    reservation.ReserveDate,
                    reservation.ExpiresAt,
                    reservation.IsClosed
                );
                reservation_output.Add(reservation_info);
            }
            return Ok(reservation_output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReservation([FromRoute] Guid id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            var bookinfo = await _bookService.GetBookAsync(reservation.BookCopyId);
            var userinfo = await _userService.GetUserAsync(reservation.UserId);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservation_info = new ReservationGetRequest(
                new(userinfo.FirstName,
                    userinfo.LastName),
                reservation.ReserveDate,
                reservation.ExpiresAt,
                reservation.IsClosed);
            return Ok(reservation_info);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationAddRequest reservRequest)
        {
            bool ableToReserve =  await _reservationService.CreateReservationAsync(reservRequest);
            if (!ableToReserve)
                return Ok("Cannot make reservation because either user has to much reservations or there are no available books");

            return Ok(reservRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, ReservationUpdateRequest reservUpdateRequest)
        {
            var reservation = await _reservationService.UpdateReservationAsync(id, reservUpdateRequest);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservUpdateRequest);

        }
    }
}
