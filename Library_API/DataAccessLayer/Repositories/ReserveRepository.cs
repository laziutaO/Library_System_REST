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
    public class ReserveRepository : BaseRepository<Reservation>, IReserveRepository
    {
        LibraryDbContext _libraryDbContext;
        public ReserveRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public int CheckReservationsCount(Guid userId)
        {
            var count = libraryDbContext.Reservations.Where(u => u.UserId == userId && u.IsClosed == false).Count();
            return count;
        }

        public new async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            List<Reservation> reservations = await _libraryDbContext.Reservations
                .Include(r => r.User)
                .Include(r => r.BookCopy)
                .ToListAsync();
            return reservations;
        }

        public new async Task<Reservation?> GetAsync(Guid id)
        {
            var reservation = await _libraryDbContext.Reservations
                .Where(r => r.Id == id)
                .Include(r => r.User)
                .Include(r => r.BookCopy)
                .FirstOrDefaultAsync();
            return reservation;
        }

        //to finish
        public async Task<bool> CheckIfCanReserveAsync(Guid userId, Guid bookId)
        {
            bool userIsBlocked = await _libraryDbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => u.IsBlocked)
                .FirstOrDefaultAsync();

            int availableSamples = 1;

            return !userIsBlocked && availableSamples > 0;
        }
    }
}
