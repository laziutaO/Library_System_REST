using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record BorrowingCreateRequest(
        Guid UserId,
        Guid BookCopyId,
        DateOnly DueDate);
}
