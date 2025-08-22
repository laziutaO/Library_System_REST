using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record BorrowingGetRequest(
        string UserName,
        string BookTitle,
        DateOnly BorrowedDate,
        DateOnly DueDate,
        DateOnly? ReturnedAt,
        bool IsOverdue);
}
