using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record LibraryUpdateRequest(
       string description,
       string coverImageUrl,
       string name,
       string address,
       string phone,
       string email,
       int studyRooms,
       int computers,
       List<LibraryScheduleUpdateRequest> schedule);
}
