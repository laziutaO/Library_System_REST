using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewRepository: IBaseRepository<Review>
    {
        new Task<IEnumerable<Review>> GetAllAsync();
        new Task<Review?> GetAsync(Guid id);

        Task<List<Review>> GetByUserAsync(Guid userId);
        Task<List<Review>> GetByBookAsync(Guid userId);
    }
}
