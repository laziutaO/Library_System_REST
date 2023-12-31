using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationAsync(Guid id);

        Task CreateReservationAsync(Reservation reserv);
        Task<Reservation> UpdateReservationAsync(Guid id, Reservation reserv);
        Task<Reservation> DeleteReservationAsync(Guid id);
    }
}
