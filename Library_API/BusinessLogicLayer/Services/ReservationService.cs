using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReserveRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public ReservationService(IReserveRepository repository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<bool> CreateReservationAsync(ReservationAddRequest reservationInfo)
        {
            var reserv = new Reservation();
            var userId = await _userRepository.GetIdAsync(reservationInfo.UserInfo.FirstName, reservationInfo.UserInfo.LastName);
            var bookId = await _bookRepository.GetIdAsync(reservationInfo.BookInfo.Title);
            reserv.UserId = userId;
            reserv.BookCopyId = bookId;
            var book = await _bookRepository.GetAsync(bookId);
            var count = _repository.CheckReservationsCount(userId);
            if(count < 10)
            {
                reserv.ReserveDate = reservationInfo.ReserveDate;
                reserv.ExpiresAt = reservationInfo.ReturnDate;
                reserv.IsClosed = false;
                await _repository.CreateAsync(reserv);
                return true;
            }
            
            return false;
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

        public async Task<Reservation> UpdateReservationAsync(Guid id, ReservationUpdateRequest reserv)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation == null)
            {
                return null;
            }

            reservation.ReserveDate = reserv.ReserveDate;
            reservation.ExpiresAt = reserv.ReturnDate;
            reservation.IsClosed = reserv.IsClosed;

            await _repository.UpdateAsync();

            return reservation;
        }
    }
}
