using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BookCopyService : BookService<BookCopy>, IBookCopyService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        public BookCopyService(IBookCopyRepository repository, 
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository) : base(repository)
        {
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _bookCopyRepository = repository;
        }

        public async Task<BookCopyGetRequest> CreateBookAsync(BookCopyCreateRequest book_info)
        {
            BookCopy book = new BookCopy();

            book_info.CreateRequestToBookCopy(book);
            await _authorRepository.CreateMissingAsync(book_info.AuthorNames);
            await _genreRepository.CreateMissingAsync(book_info.GenreNames);
            await _bookCopyRepository.CreateAsync(book, book_info.AuthorNames, book_info.GenreNames, book_info.LibraryNames);

            return book.BookCopyToGetDto();
        }

        public async Task<BookCopyGetRequest?> UpdateBookAsync(Guid id, BookCopyUpdateRequest book_info)
        {
            var book = await _bookCopyRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }

            book_info.UpdateRequestToBookCopy(book);
            await _authorRepository.CreateMissingAsync(book_info.AuthorNames);
            await _genreRepository.CreateMissingAsync(book_info.GenreNames);
            await _bookCopyRepository.UpdateAsync(book, book_info.AuthorNames, book_info.GenreNames, book_info.LibraryNames);
            var bookCopyDto = book.BookCopyToGetDto();
            return bookCopyDto;
        }

        public new async Task<IEnumerable<BookCopyGetRequest>> GetAllBooksAsync()
        {
            var books = await _bookCopyRepository.GetAllAsync();
            var booksDto = books.Select(b => b.BookCopyToGetDto());
            return booksDto;
        }

        public new async Task<IEnumerable<BookCopyGetRequest>> GetBooksAsync(string keyword)
        {
            var books = await _bookCopyRepository.GetBooksAsync(keyword);
            var booksDto = books.Select(b => b.BookCopyToGetDto());
            return booksDto;
        }

        public new async Task<IEnumerable<BookCopyGetRequest>> GetBooksByGenreAsync(List<string> genres)
        {
            var books = await _bookCopyRepository.GetBooksByGenreAsync(genres);
            var booksDto = books.Select(b => b.BookCopyToGetDto());
            return booksDto;
        }
    }
}
