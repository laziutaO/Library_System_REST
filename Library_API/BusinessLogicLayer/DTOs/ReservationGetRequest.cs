using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record ReservationGetRequest(
        string bookTitle,
        Guid userId,
        Guid libraryId,
        DateOnly reserveDate, 
        DateOnly expiresAt, 
        bool isClosed);
    
}
