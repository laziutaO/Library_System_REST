using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record UserUpdateRequest(
        string FirstName,
        string LastName,
        string Phone,
        string Email,
        bool IsBlocked);
}
