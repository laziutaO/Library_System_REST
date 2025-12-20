using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BorrowingRepository: BaseRepository<Borrowing>, IBorrowingRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public BorrowingRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)  
        {
            _libraryDbContext = libraryDbContext;
        }

        public new async Task<Borrowing?> GetAsync(Guid id)
        {
            var reservation = await _libraryDbContext.Borrowings
                .Where(r => r.Id == id)
                .Include(r => r.BookCopy)
                .FirstOrDefaultAsync();
            return reservation;
        }
        public async Task<List<Borrowing>> GetByUserAsync(Guid userId)
        {
            List<Borrowing> reservationList = await _libraryDbContext.Borrowings
                //.Where(r => r.UserId == userId)
                .Include(r => r.BookCopy).ToListAsync();
            return reservationList;
        }

        public async Task<List<Borrowing>> GetByBookAsync(Guid bookId)
        {
            List<Borrowing> reservationList = await _libraryDbContext.Borrowings
                .Where(r => r.BookCopyId == bookId)
                .Include(r => r.BookCopy).ToListAsync();
            return reservationList;
        }

        //to finish
        //public async Task<bool> CheckIfCanBorrowAsync(Guid userId, Guid bookId)
        //{
        //    bool userIsBlocked = await _libraryDbContext.Users
        //        .Where(u => u.Id == userId)
        //        .Select(u => u.IsBlocked)
        //        .FirstOrDefaultAsync();

        //    int availableSamples = 1;

        //    return !userIsBlocked && availableSamples > 0;
        //}
    }
}
