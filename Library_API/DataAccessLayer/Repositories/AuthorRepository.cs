using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AuthorRepository : IBaseRepository<Author>
    {
        private readonly LibraryDbContext _libraryDbContext;
        public AuthorRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(Author entity)
        {
            entity.Id = Guid.NewGuid();
            await _libraryDbContext.Authors.AddAsync(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author entity)
        {
            _libraryDbContext.Authors.Remove(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _libraryDbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAsync(Guid id)
        {
            var author = await _libraryDbContext.Authors.FirstOrDefaultAsync(u => u.Id == id);
            return author;
        }

        public async Task UpdateAsync()
        {
            await _libraryDbContext.SaveChangesAsync();
        }
    }
}
