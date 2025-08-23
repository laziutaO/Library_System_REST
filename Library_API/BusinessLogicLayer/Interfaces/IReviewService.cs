using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewGetRequest>> GetAllReviewsAsync();
        Task<ReviewGetRequest?> GetReviewAsync(Guid id);

        Task<ReviewGetRequest> CreateReviewAsync(ReviewCreateRequest request);
        Task<ReviewGetRequest?> UpdateReviewAsync(Guid id, ReviewUpdateRequest request);
        Task<ReviewGetRequest?> DeleteReviewAsync(Guid id);

        Task<List<ReviewGetRequest>?> GetReviewsByUserAsync(Guid userId);
        Task<List<ReviewGetRequest>?> GetReviewsByBookAsync(Guid bookId);
    }
}
