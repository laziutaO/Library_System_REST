using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPasswordHelper
    {
        string GeneratePassword(User user, string providedPassword);
        bool VerifyHashedPassword(User user, string providedPassword, string hashedPassword);
    }
}
