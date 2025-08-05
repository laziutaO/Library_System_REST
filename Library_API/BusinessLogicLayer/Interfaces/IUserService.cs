using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid id);

        Task CreateUserAsync(UserAddRequest user);
        Task<User> UpdateUserAsync(Guid id, UserAddRequest user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
