using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService) 
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetGenreResponcesAsync();
            var output = new Dictionary<string, IEnumerable<GenreGetResponce>>()
            {
                ["genres"] = genres
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetGenreById([FromRoute] Guid id)
        {
            var genre = await _genreService.GetGenreAsync(id);

            if (genre == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, GenreGetResponce>()
            {
                ["genre"] = genre
            };
            return Ok(output);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateGenre([FromRoute] Guid id, [FromBody] GenreUpdateRequest updateRequest)
        {
            var genre = await _genreService.UpdateGenreAsync(id, updateRequest);
            if (genre == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreCreateRequest createRequest)
        {
            var genre = await _genreService.CreateGenreAsync(createRequest);
            var output = new Dictionary<string, GenreGetResponce>()
            {
                ["genre"] = genre
            };
            return CreatedAtAction(nameof(AddGenre), output);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
        {
            var genre = await _genreService.DeleteGenreAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
