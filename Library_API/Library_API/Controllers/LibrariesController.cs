using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LibrariesController : Controller
    {
        private readonly ILibraryService _libraryService;
        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
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
            return Ok(libraryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddLibrary([FromBody] LibraryRequest request)
        {
            var libraryDto = await _libraryService.CreateLibraryAsync(request);
            return Ok(libraryDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateLibrary([FromRoute] Guid id, [FromBody] LibraryRequest request)
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
            return Ok(library);
        }
    }
}
