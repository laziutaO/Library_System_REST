using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.DTOs;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        public BooksController(IBookService bookService, IAuthorService authorService) 
        { 
            _bookService = bookService;
            _authorService = authorService;
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
            var bookRequest =  await _bookService.GetBookAsync(id);
            var author = await _authorService.GetAuthorAsync(bookRequest.AuthorId);
            if (bookRequest == null)
            {
                return NotFound();
            }
            BookGetDto bookGetDto = new BookGetDto
            {
                Title = bookRequest.Title,
                Category = bookRequest.Category,
                AvailableSamples = bookRequest.AvailableSamples,
                AuthorInfo = new AuthorGetDto
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                }
            };
            

            return Ok(bookGetDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookCreateDto bookRequest)
        {
            //[FromBody] 
            Book book = new Book
            {
                Title = bookRequest.Title,
                Category = bookRequest.Category,
                AvailableSamples = bookRequest.AvailableSamples,
            };

            Author author = new Author
            {
                FirstName = bookRequest.Author.FirstName,
                LastName = bookRequest.Author.LastName,
            };
            if (author.Books == null){
                author.Books = new List<Book>();
            }
            author.Books.Add(book);
            book.Author = author;

            await _bookService.CreateBookAsync(book);

            return Ok(bookRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, BookUpdateDto bookUpdateRequest)
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
