﻿using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : Controller
    {

        private readonly IUserService userService;
        public UsersController(IUserService userService) 
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserAddDto userRequest)
        {
            await userService.CreateUserAsync(userRequest);

            return Ok(userRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UserAddDto userUpdateRequest)
        {
            var user = await userService.UpdateUserAsync(id, userUpdateRequest);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
    
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await userService.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
