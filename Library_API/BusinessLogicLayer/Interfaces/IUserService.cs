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
        Task<IEnumerable<UserGetRequest>> GetAllUsersAsync();
        Task<UserGetRequest?> GetUserAsync(Guid id);

        Task CreateUserAsync(UserCreateRequest user);
        Task<UserGetRequest?> UpdateUserAsync(Guid id, UserUpdateRequest user);
        Task<UserGetRequest?> DeleteUserAsync(Guid id);
    }
}
