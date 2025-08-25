using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicLayer.Interfaces;

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
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateRequest userRequest)
        {
            await _userService.CreateUserAsync(userRequest);

            return Ok(userRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody]UserUpdateRequest userUpdateRequest)
        {
            var user = await _userService.UpdateUserAsync(id, userUpdateRequest);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _userService.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
