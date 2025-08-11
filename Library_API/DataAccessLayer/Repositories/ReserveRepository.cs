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
    public class ReserveRepository :BaseRepository<Reservation>, IReserveRepository
    {
        public ReserveRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext) { }

        public int CheckReservationsCount(Guid userId)
        {
            var count = libraryDbContext.Reservations.Where(u => u.UserId == userId && u.IsClosed == false).Count();
            return count;
        }


    }
}
