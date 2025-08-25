using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Facet.Extensions.EFCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {

        public UserRepository(LibraryDbContext libraryDbContext): base(libraryDbContext)
        {

        }

        public async Task<Guid> GetIdAsync(string firstName, string lastName)
        {
            var user = await libraryDbContext.Users.FirstOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.Id;
        }

    }
}
