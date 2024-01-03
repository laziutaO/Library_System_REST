using BusinessLogicLayer;
using DataAccessLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthorsController: Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAuthor([FromRoute] Guid id)
        {
            var author = await _authorService.GetAuthorAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorUpdateDto authorRequest)
        {
            await _authorService.CreateAuthorAsync(authorRequest);

            return Ok(authorRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] Guid id, AuthorUpdateDto authorUpdateRequest)
        {
            var author = await _authorService.UpdateAuthorAsync(id, authorUpdateRequest);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var author = await _authorService.DeleteAuthorAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
