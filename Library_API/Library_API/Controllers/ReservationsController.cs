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
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public ReservationsController(IReservationService reservationService, IBookService bookService, IUserService userService)
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
            List<ReservationGetDto> reservation_output = new List<ReservationGetDto>();
            foreach(var reservation in reservations)
            {
                var bookinfo = await _bookService.GetBookAsync(reservation.BookId);
                var userinfo = await _userService.GetUserAsync(reservation.UserId);
                var reservation_info = new ReservationGetDto
                {
                    BookInfo = new BookGetShortDto
                    {
                        Title = bookinfo.Title,
                    },
                    UserInfo = new UserGetDto
                    {
                        FirstName = userinfo.FirstName,
                        LastName = userinfo.LastName,
                    },
                    ReserveDate = reservation.ReserveDate,
                    ReturnDate = reservation.ReturnDate,
                    IsClosed = reservation.IsClosed,

                };
                reservation_output.Add(reservation_info);
            }
            return Ok(reservation_output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReservation([FromRoute] Guid id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            var bookinfo = await _bookService.GetBookAsync(reservation.BookId);
            var userinfo = await _userService.GetUserAsync(reservation.UserId);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservation_info = new ReservationGetDto
            {
                BookInfo = new BookGetShortDto
                {
                    Title = bookinfo.Title,
                },
                UserInfo = new UserGetDto
                {
                    FirstName = userinfo.FirstName,
                    LastName = userinfo.LastName,
                },
                ReserveDate = reservation.ReserveDate,
                ReturnDate = reservation.ReturnDate,
                IsClosed = reservation.IsClosed,

            };
            return Ok(reservation_info);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationAddDto reservRequest)
        {
            await _reservationService.CreateReservationAsync(reservRequest);

            return Ok(reservRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, ReservationUpdateDto reservUpdateRequest)
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
