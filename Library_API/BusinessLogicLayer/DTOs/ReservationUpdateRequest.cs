using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record ReservationUpdateRequest(
        Guid UserId, 
        Guid BookCopyId, 
        bool IsClosed);
}
