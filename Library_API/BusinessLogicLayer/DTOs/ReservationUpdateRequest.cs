using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record ReservationUpdateRequest(DateOnly ReserveDate, DateOnly ReturnDate, bool IsClosed);
   
}
