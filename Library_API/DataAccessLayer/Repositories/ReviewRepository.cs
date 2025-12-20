using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ReviewRepository:BaseRepository<Review>, IReviewRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public ReviewRepository(LibraryDbContext libraryDbContext): base(libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async new Task<IEnumerable<Review>> GetAllAsync()
        {
            var reviews = await _libraryDbContext.Reviews
                .Include(r => r.Book)
                .ToListAsync();
            return reviews;
        }
        public async new Task<Review?> GetAsync(Guid id)
        {
            var review = await _libraryDbContext.Reviews
                .Include(r => r.Book)
                .FirstOrDefaultAsync();
            return review;
        }
        public async Task<List<Review>> GetByUserAsync(Guid userId)
        {
            var reviews = await _libraryDbContext.Reviews
                //.Where(r => r.UserId == userId)
                .Include(r => r.Book)
                .ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> GetByBookAsync(Guid bookId)
        {
            var reviews = await _libraryDbContext.Reviews
                .Where(r => r.BookId == bookId)
                .Include(r => r.Book)
                .ToListAsync();
            return reviews;
        }
    }
}
