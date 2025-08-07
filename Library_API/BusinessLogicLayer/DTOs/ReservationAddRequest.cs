using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct ReservationAddRequest(BookGetShortRequest BookInfo, UserGetRequest UserInfo, DateOnly ReserveDate, DateOnly ReturnDate);
  
}
