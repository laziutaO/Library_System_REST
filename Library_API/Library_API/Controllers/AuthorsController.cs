using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Mapping;

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
            var authorDto = await _authorService.GetAuthorAsync(id);

            if (authorDto == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, AuthorGetRequest>()
            {
                ["author"] = authorDto
            };
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorCreateRequest authorRequest)
        {
            var author = await _authorService.CreateAuthorAsync(authorRequest);
            var output = new Dictionary<string, AuthorGetRequest>()
            {
                ["author"] = author
            };
            return CreatedAtAction(nameof(AddAuthor), output);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] Guid id, AuthorUpdateRequest authorUpdateRequest)
        {
            var author = await _authorService.UpdateAuthorAsync(id, authorUpdateRequest);

            if (author == null)
            {
                return NotFound();
            }

            return NoContent();

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

            return NoContent();
        }
    }
}
