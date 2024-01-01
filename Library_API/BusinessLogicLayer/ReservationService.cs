using DataAccessLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ReservationService : IReservationService
    {
        private readonly IBaseRepository<Reservation> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public ReservationService(IBaseRepository<Reservation> repository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task CreateReservationAsync(ReservationAddDto reservationInfo)
        {
            var reserv = new Reservation();
            reserv.UserId = await _userRepository.GetIdAsync(reservationInfo.UserInfo.FirstName, reservationInfo.UserInfo.LastName);
            reserv.BookId = await _bookRepository.GetIdAsync(reservationInfo.BookInfo.Title);
            reserv.ReserveDate = reservationInfo.ReserveDate;
            reserv.ReturnDate = reservationInfo.ReturnDate;
            reserv.IsClosed = false;
            await _repository.CreateAsync(reserv);
        }

        public async Task<Reservation> DeleteReservationAsync(Guid id)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation == null)
            {
                return null;
            }

            await _repository.DeleteAsync(reservation);

            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationAsync(Guid id)
        {
            var reservation = await _repository.GetAsync(id);

            return await _repository.GetAsync(id);
        }

        public async Task<Reservation> UpdateReservationAsync(Guid id, ReservationUpdateDto reserv)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation == null)
            {
                return null;
            }

            reservation.ReserveDate = reserv.ReserveDate;
            reservation.ReturnDate = reserv.ReturnDate;
            reservation.IsClosed = reserv.IsClosed;

            await _repository.UpdateAsync();

            return reservation;
        }
    }
}
