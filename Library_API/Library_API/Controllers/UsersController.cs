using Library_API.Controllers.Data;
using Library_API.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        public UsersController(LibraryDbContext libraryDbContext) 
        {
            this.libraryDbContext = libraryDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await libraryDbContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User userRequest)
        {
            userRequest.Id = Guid.NewGuid();
            await libraryDbContext.Users.AddAsync(userRequest);
            await libraryDbContext.SaveChangesAsync();

            return Ok(userRequest);
        }
    }
}
