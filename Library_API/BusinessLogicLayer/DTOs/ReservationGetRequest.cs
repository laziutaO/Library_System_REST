using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record ReservationGetRequest(
        string UserName, 
        string BookTitle, 
        DateOnly ReserveDate, 
        DateOnly ExpiresAt, 
        bool IsClosed);
    
}
