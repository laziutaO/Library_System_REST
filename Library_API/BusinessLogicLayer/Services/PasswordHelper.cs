using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class PasswordHelper: IPasswordHelper
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public PasswordHelper(IPasswordHasher<User> passwordHasher) 
        {
            _passwordHasher = passwordHasher;
        }

        public string GeneratePassword(User user, string providedPassword) 
        { 
            return _passwordHasher.HashPassword(user, providedPassword);
        }

        public bool VerifyHashedPassword(User user, string providedPassword, string hashedPassword) 
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
