using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserGetResponce> GetCurrentAsync(ClaimsPrincipal claims);
        Task<IEnumerable<UserGetResponce>> GetAllUsersAsync();
        Task<UserGetResponce?> GetUserAsync(Guid id);
        Task<UserGetResponce?> UpdateUserAsync(Guid id, UserUpdateRequest request);
        Task<UserGetResponce?> DeleteUserAsync(Guid id);
    }
}
