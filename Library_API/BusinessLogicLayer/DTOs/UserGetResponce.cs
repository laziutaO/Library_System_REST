using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record UserGetResponce(
        string id,
        string firstName,
        string lastName,
        string userName,
        string email,
        bool isBlocked);
}
