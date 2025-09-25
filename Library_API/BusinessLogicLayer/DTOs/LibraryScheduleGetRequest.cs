using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record LibraryScheduleGetRequest(
        string id,
        string dayOfWeek,
        string? openTime,
        string? closeTime,
        bool isClosed);
}
