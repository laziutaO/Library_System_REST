using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataAccessLayer.Entities;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var book =  await _bookService.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book bookRequest)
        {
            var authorId = bookRequest.AuthorId;
            await _bookService.CreateBookAsync(bookRequest, authorId);

            return Ok(bookRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, Book bookUpdateRequest)
        {
            var book = await _bookService.UpdateBookAsync(id, bookUpdateRequest);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

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

            return Ok(book);
        }
    }
}
