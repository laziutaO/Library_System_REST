using BusinessLogicLayer.DTOs;


namespace BusinessLogicLayer.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationGetRequest>> GetAllReservationsAsync();
        Task<ReservationGetRequest?> GetReservationAsync(Guid id);

        Task<ReservationGetRequest> CreateReservationAsync(ReservationCreateRequest reserv, Guid userId);
        Task<ReservationGetRequest?> UpdateReservationAsync(Guid id, ReservationUpdateRequest reserv);
        Task<ReservationGetRequest> DeleteReservationAsync(Guid id);

        Task<List<ReservationGetRequest>?> GetReservationsByUserAsync(Guid userId);
        Task<List<ReservationGetRequest>?> GetReservationsByBookAsync(Guid bookId);
    }
}
