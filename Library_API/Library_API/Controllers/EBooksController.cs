using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EBooksController: Controller
    {
        private readonly IEbookService _bookService;
        public EBooksController(IEbookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            var output = new Dictionary<string, IEnumerable<EBookGetResponce>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var bookRequest =  await _bookService.GetBookAsync(id);
            
            if (bookRequest == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, EBookGetResponce>()
            {
                ["book"] = bookRequest.EbookToGetResponce()
            };
            return Ok(output);
        }
        // to improve
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetBooksByKeyword([FromBody] string keyword)
        {
            keyword = keyword ?? string.Empty;
       
            var books = await _bookService.GetBooksAsync(keyword);
            var output = new Dictionary<string, IEnumerable<EBookGetResponce>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }


        [HttpGet]
        [Route("genres")]
        public async Task<IActionResult> GetBooksByCategory([FromBody] List<string> genre)
        {
            var books = await _bookService.GetBooksByGenreAsync(genre);
            var output = new Dictionary<string, IEnumerable<EBookGetResponce>>()
            {
                ["books"] = books
            };
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(EBookCreateRequest bookRequest)
        {
            var book = await _bookService.CreateBookAsync(bookRequest);
            var output = new Dictionary<string, EBookGetResponce>()
            {
                ["book"] = book
            };
            return CreatedAtAction(nameof(AddBook), output);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] EBookUpdateRequest bookUpdateRequest)
        {
            var book = await _bookService.UpdateBookAsync(id, bookUpdateRequest);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var book = await _bookService.DeleteBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
