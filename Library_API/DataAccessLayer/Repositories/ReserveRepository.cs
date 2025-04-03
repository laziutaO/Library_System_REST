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
    public class ReserveRepository : IReserveRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public ReserveRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(Reservation entity)
        {
            entity.Id = Guid.NewGuid();
            await _libraryDbContext.Reservations.AddAsync(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation entity)
        {
            _libraryDbContext.Reservations.Remove(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _libraryDbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetAsync(Guid id)
        {
            var reservation = await _libraryDbContext.Reservations.FirstOrDefaultAsync(u => u.Id == id);
            return reservation;
        }

        public async Task UpdateAsync()
        {
            await _libraryDbContext.SaveChangesAsync();
        }

        public int CheckReservationsCount(Guid userId)
        {
            var count = _libraryDbContext.Reservations.Where(u => u.UserId == userId && u.IsClosed == false).Count();
            return count;
        }


    }
}
