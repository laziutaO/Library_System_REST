using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(Guid id);

        Task CreateAsync(User entity);
        Task UpdateAsync();
        Task DeleteAsync(User entity);

        Task<Guid> GetIdAsync(string firstName, string lastName);
    }
}
