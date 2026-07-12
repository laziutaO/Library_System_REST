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
    //[Authorize]
    public class AuthorsController: Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            if (authors == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<AuthorGetRequest>>()
            {
                ["authors"] = authors
            };
            return Ok(output);
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
        
        [Authorize(Roles = "Admin")]
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
        
        [Authorize(Roles = "Admin")]
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
        
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
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
