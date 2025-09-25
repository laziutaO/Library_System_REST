using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record LibraryScheduleCreateRequest(
        string dayOfWeek,
        string? openTime,
        string? closeTime,
        bool isClosed);
}
