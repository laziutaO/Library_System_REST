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

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await libraryDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User userUpdateRequest)
        {
            var user = await libraryDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = userUpdateRequest.FirstName;
            user.LastName = userUpdateRequest.LastName;
            user.Phone = userUpdateRequest.Phone;

            await libraryDbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
