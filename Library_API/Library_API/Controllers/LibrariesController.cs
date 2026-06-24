using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class LibrariesController : Controller
    {
        private readonly ILibraryService _libraryService;
        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibraries()
        {
            var libraries = await _libraryService.GetLibrariesAsync();
            var output = new Dictionary<string, IEnumerable<LibraryRequest>>()
            {
                ["libraries"] = libraries
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetLibrary([FromRoute] Guid id)
        {
            var libraryDto = await _libraryService.GetLibraryAsync(id);
            if (libraryDto == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, LibraryRequest>()
            {
                ["library"] = libraryDto
            };
            return Ok(output);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddLibrary([FromBody] LibraryCreateRequest request)
        {
            var libraryDto = await _libraryService.CreateLibraryAsync(request);
            var output = new Dictionary<string, LibraryRequest>()
            {
                ["library"] = libraryDto
            };
            return CreatedAtAction(nameof(AddLibrary), output);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("{libraryId:Guid}/books")]
        public async Task<IActionResult> AddBookToLibrary([FromRoute] Guid libraryId, [FromBody] BookIdDto bookRequest)
        {
            var bookDto = await _libraryService.AddBookToLibrary(libraryId, bookRequest);
            if(bookDto == null)
            {
                return NotFound(bookRequest.bookId);
            }
            var output = new Dictionary<string, BookCopyGetRequest>()
            {
                ["book"] = bookDto
            };
            return CreatedAtAction(nameof(AddBookToLibrary), output);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{libraryId:Guid}/books")]
        public async Task<IActionResult> RemoveBook([FromRoute] Guid libraryId, [FromBody] string bookId)
        {
            var libraryBook = await _libraryService.RemoveBookToLibrary(libraryId, bookId);
            if (libraryBook == null)
            {
                return NotFound(bookId);
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateLibrary([FromRoute] Guid id, [FromBody] LibraryUpdateRequest request)
        {
            var library = await _libraryService.GetLibraryAsync(id);
            if (library == null)
            {
                return NotFound(request);
            }
            var libraryDto = await _libraryService.UpdateLibraryAsync(id, request);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteLibrary([FromRoute] Guid id)
        {
            var library = await _libraryService.DeleteLibraryAsync(id);
            if(library == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
