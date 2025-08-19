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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected LibraryDbContext libraryDbContext;
        public BaseRepository(LibraryDbContext libraryDbContext) 
        {
            this.libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await libraryDbContext.Set<TEntity>().AddAsync(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            libraryDbContext.Set<TEntity>().Remove(entity);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => 
            await libraryDbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetAsync(Guid id) => 
            await libraryDbContext.Set<TEntity>().FindAsync(id);
        

        public async Task UpdateAsync()
        {
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
