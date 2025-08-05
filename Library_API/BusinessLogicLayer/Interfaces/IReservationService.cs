using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationAsync(Guid id);

        Task<bool> CreateReservationAsync(ReservationAddRequest reserv);
        Task<Reservation> UpdateReservationAsync(Guid id, ReservationUpdateRequest reserv);
        Task<Reservation> DeleteReservationAsync(Guid id);
    }
}
