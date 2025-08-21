using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Mapping;
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
        public ReservationService(IReserveRepository repository, 
            IUserRepository userRepository, 
            IBookRepository<BookCopy> bookRepository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckIfCanReserve(Guid userId, Guid bookId)
        {
            return await _repository.CheckIfCanReserveAsync(userId, bookId);
        }
        public async Task<ReservationGetRequest> CreateReservationAsync(ReservationCreateRequest reservationInfo)
        {
            Reservation reservation = new Reservation();
            reservationInfo.CreateDtoToReservation(reservation);
            await _repository.CreateAsync(reservation);
            var fetchedReservation = await _repository.GetAsync(reservation.Id);
            if (fetchedReservation == null)
            {
                throw new InvalidOperationException("Reservation could not be retrieved after creation.");
            }
            return fetchedReservation.ReservationToGetDto();
        }

        public async Task<ReservationGetRequest> DeleteReservationAsync(Guid id)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation == null)
            {
                return null;
            }

            await _repository.DeleteAsync(reservation);

            return reservation.ReservationToGetDto();
        }

        public async Task<IEnumerable<ReservationGetRequest>> GetAllReservationsAsync()
        {
            var reservations = await _repository.GetAllAsync();
            var reservationsResponce = reservations.Select(r => r.ReservationToGetDto()).ToList();
            return reservationsResponce;
        }

        public async Task<ReservationGetRequest?> GetReservationAsync(Guid id)
        {
            var reservation = await _repository.GetAsync(id);
            return reservation == null ? null : reservation.ReservationToGetDto();
        }

        public async Task<ReservationGetRequest?> UpdateReservationAsync(Guid id, ReservationUpdateRequest reserv)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation == null)
            {
                return null;
            }
            reserv.UpdateDtoToReservation(reservation);
            await _repository.UpdateAsync();

            return reservation.ReservationToGetDto();
        }

        public async Task<List<ReservationGetRequest>?> GetReservationsByUserAsync(Guid userId)
        {
            var reservations = await _repository.GetByUserAsync(userId);
            if (reservations == null)
            {
                return null;
            }
            var reservationsList = reservations.Select(r=>r.ReservationToGetDto()).ToList();
            return reservationsList;
        }

        public async Task<List<ReservationGetRequest>?> GetReservationsByBookAsync(Guid bookId)
        {
            var reservations = await _repository.GetByBookAsync(bookId);
            if (reservations == null)
            {
                return null;
            }
            var reservationsList = reservations.Select(r => r.ReservationToGetDto()).ToList();
            return reservationsList;
        }
    }
}
