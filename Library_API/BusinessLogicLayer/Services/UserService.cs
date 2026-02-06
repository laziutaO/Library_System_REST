using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace BusinessLogicLayer.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }

        public async Task<UserGetResponce> GetCurrentAsync(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            return new(
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.IsBlocked
            );
        }

        public async Task<UserGetResponce?> DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            await _userManager.DeleteAsync(user);
            return new(
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.IsBlocked
            );
        }

        public async Task<IEnumerable<UserGetResponce>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return users.Select(user => new UserGetResponce(
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.IsBlocked
            ));
        }

        public async Task<UserGetResponce?> GetUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            return new(
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.IsBlocked
            );
        }

        public async Task<UserGetResponce?> UpdateUserAsync(Guid id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            user.IsBlocked = request.isBlocked;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
                return new(
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                request.isBlocked
                );
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }
    }
}
