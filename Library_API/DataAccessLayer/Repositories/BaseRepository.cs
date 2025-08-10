using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected LibraryDbContext libraryDbContext;
        public BaseRepository(LibraryDbContext libraryDbContext) 
        {
            this.libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(T entity)
        {
            await libraryDbContext.Set<T>().AddAsync(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            libraryDbContext.Set<T>().Remove(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => 
            await libraryDbContext.Set<T>().ToListAsync();

        public async Task<T> GetAsync(Guid id) => 
            await libraryDbContext.Set<T>().FindAsync(id);
        

        public async Task UpdateAsync()
        {
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
