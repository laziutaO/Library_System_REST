using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record UserCreateRequest(
        string FirstName,
        string LastName,
        string Phone,
        string Email,
        string Password,
        bool IsBlocked);
}
