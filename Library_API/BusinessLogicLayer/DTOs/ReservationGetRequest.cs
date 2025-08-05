using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct ReservationGetRequest(BookGetShortRequest BookInfo, UserGetRequest UserInfo, DateTime ReserveDate, DateTime ReturnDate, bool IsClosed);
    
}
