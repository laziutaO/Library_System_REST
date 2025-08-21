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
        Task<IEnumerable<ReservationGetRequest>> GetAllReservationsAsync();
        Task<ReservationGetRequest?> GetReservationAsync(Guid id);

        Task<ReservationGetRequest> CreateReservationAsync(ReservationCreateRequest reserv);
        Task<ReservationGetRequest?> UpdateReservationAsync(Guid id, ReservationUpdateRequest reserv);
        Task<ReservationGetRequest> DeleteReservationAsync(Guid id);

        Task<bool> CheckIfCanReserve(Guid userId, Guid bookId);
    }
}
