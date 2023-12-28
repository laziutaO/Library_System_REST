using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly LibraryDbContext libraryDbContext;

        public UserRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(User entity)
        {
            entity.Id = Guid.NewGuid();
            await libraryDbContext.Users.AddAsync(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            libraryDbContext.Users.Remove(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await libraryDbContext.Users.ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await libraryDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task UpdateAsync()
        {
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
