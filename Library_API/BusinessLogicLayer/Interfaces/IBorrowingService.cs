using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBorrowingService
    {
        Task<BorrowingGetRequest?> GetBorrowingAsync(Guid id);
        Task<BorrowingGetRequest> CreateBorrowingAsync(BorrowingCreateRequest reserv);
        Task<BorrowingGetRequest?> UpdateBorrowingAsync(Guid id, BorrowingUpdateRequest reserv);
        Task<BorrowingGetRequest> DeleteBorrowingAsync(Guid id);
        Task<List<BorrowingGetRequest>?> GetBorrowingsByUserAsync(Guid userId);
        Task<List<BorrowingGetRequest>?> GetBorrowingsByBookAsync(Guid bookId);
    }
}
