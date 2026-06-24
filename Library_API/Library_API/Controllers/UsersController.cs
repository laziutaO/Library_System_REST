using Azure.Core;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetMe()
        {
            var user = await _userService.GetCurrentAsync(User);
            return Ok(new Dictionary<string, UserGetResponce>()
            {
                ["user"] = user
            });
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new Dictionary<string, UserGetResponce>()
            {
                ["user"] = user
            });
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(new Dictionary<string, IEnumerable<UserGetResponce>>()
            {
                ["users"] = users
            });

        }
        
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserUpdateRequest request)
        {
            var user = await _userService.UpdateUserAsync(id, request);
            if (user == null)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _userService.DeleteUserAsync(id);
            if (user == null)
                return NotFound();

            return NoContent();
        }
    }
}
