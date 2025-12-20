using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReserveRepository: IBaseRepository<Reservation>
    {
        
        new Task<IEnumerable<Reservation>> GetAllAsync();
        new Task<Reservation?> GetAsync(Guid id);

        //Task<bool> CheckIfCanReserveAsync(Guid userId, Guid bookId);

        Task<List<Reservation>> GetByUserAsync(Guid userId);
        Task<List<Reservation>> GetByBookAsync(Guid userId);
    }
}
