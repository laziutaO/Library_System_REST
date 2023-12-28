using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid id);

        Task CreateUserAsync(User user);
        Task<User> UpdateUserAsync(Guid id, User user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
