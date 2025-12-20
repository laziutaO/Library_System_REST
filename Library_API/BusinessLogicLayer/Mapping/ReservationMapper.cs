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
        public static ReservationGetRequest ReservationToGetDto(this Reservation reservation)
        {
            return new(
                reservation.BookCopy.Title,
                reservation.ReserveDate,
                reservation.ExpiresAt,
                reservation.IsClosed
                );
        } 

        public static void CreateDtoToReservation(this ReservationCreateRequest request, Reservation reservation)
        {
            reservation.BookCopyId = request.BookCopyId;
        }

        public static void UpdateDtoToReservation(this ReservationUpdateRequest request, Reservation reservation)
        {
            reservation.IsClosed = request.IsClosed;
        }
    }
}
