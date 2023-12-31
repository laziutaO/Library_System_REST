using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ReservationService : IReservationService
    {
        private readonly IBaseRepository<Reservation> _repository;
        public ReservationService(IBaseRepository<Reservation> repository)
        {
            _repository = repository;
        }
        public async Task CreateReservationAsync(Reservation reserv)
        {
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
            return await _repository.GetAsync(id);
        }

        public async Task<Reservation> UpdateReservationAsync(Guid id, Reservation reserv)
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
