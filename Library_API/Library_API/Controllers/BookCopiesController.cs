using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Library_API.Controllers
{
    //[Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class BookCopiesController : Controller
    {
        IBookCopyService _bookCopyService;
        public BookCopiesController(IBookCopyService bookCopyService) 
        {
            _bookCopyService = bookCopyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookCopies()
        {
            var books = await _bookCopyService.GetAllBooksAsync();
            if (books == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<BookCopyGetRequest>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBookCopy([FromRoute] Guid id)
        {
            var book = await _bookCopyService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, BookCopyGetRequest>()
            {
                ["book"] = book.BookCopyToGetDto()
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetBookCopyByKeyword([FromQuery] string keyword)
        {
            var books = await _bookCopyService.GetBooksAsync(keyword);
            if (books == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<BookCopyGetRequest>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }

        
        [HttpGet]
        [Route("genres/{genre}")]
        public async Task<IActionResult> GetBookCopyByGenre([FromRoute] string genre)
        {
            var books = await _bookCopyService.GetBooksByGenreAsync(genre);
            if (books == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<BookCopyGetRequest>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddBookCopy([FromBody] BookCopyCreateRequest request)
        {
            var book = await _bookCopyService.CreateBookAsync(request);
            var output = new Dictionary<string, BookCopyGetRequest>()
            {
                ["book"] = book
            };
            return CreatedAtAction(nameof(AddBookCopy), output);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBookCopy([FromRoute] Guid id, [FromBody] BookCopyUpdateRequest request)
        {
            var book =await _bookCopyService.UpdateBookAsync(id, request);
            if (book == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBookCopy([FromRoute] Guid id)
        {
            var book = await _bookCopyService.DeleteBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
