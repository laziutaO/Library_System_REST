using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBorrowingRepository: IBaseRepository<Borrowing>
    {
        new Task<Borrowing?> GetAsync(Guid id);
        //Task<bool> CheckIfCanBorrowAsync(Guid userId, Guid bookId);
        Task<List<Borrowing>> GetByUserAsync(Guid userId);
        Task<List<Borrowing>> GetByBookAsync(Guid userId);
    }
}
