using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class ReservationMapper
    {
        public static ReservationGetRequest ReservationToGetDto(this Reservation reservation, Guid userId)
        {
            return new(
                reservation.BookCopy.Title,
                userId,
                reservation.LibraryId,
                reservation.ReserveDate,
                reservation.ExpiresAt,
                reservation.IsClosed
                );
        } 

        public static void CreateDtoToReservation(this ReservationCreateRequest request, Reservation reservation, Guid userId)
        {
            reservation.UserId = userId;
            reservation.LibraryId = request.libraryId;
            reservation.BookCopyId = request.bookCopyId;
        }

        public static void UpdateDtoToReservation(this ReservationUpdateRequest request, Reservation reservation)
        {
            reservation.IsClosed = request.IsClosed;
        }
    }
}
