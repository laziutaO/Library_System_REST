using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Mapping;

namespace Library_API.Controllers
{
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
                ["bookCopy"] = book.BookCopyToGetDto()
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
                ["bookCopies"] = books
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("genres")]
        public async Task<IActionResult> GetBookCopyByGenre([FromBody] List<string> genres)
        {
            var books = await _bookCopyService.GetBooksByGenreAsync(genres);
            if (books == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<BookCopyGetRequest>>()
            {
                ["bookCopies"] = books
            };
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookCopy([FromBody] BookCopyCreateRequest request)
        {
            var book = await _bookCopyService.CreateBookAsync(request);
            var output = new Dictionary<string, BookCopyGetRequest>()
            {
                ["bookCopy"] = book
            };
            return CreatedAtAction(nameof(AddBookCopy), output);
        }

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
