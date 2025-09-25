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
