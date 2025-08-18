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
    public class EbookService : BookService<Ebook>, IEbookService
    {
        private readonly IEBookRepository _eBookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        public EbookService(IEBookRepository repository) : base(repository)
        {
            _eBookRepository = repository;
        }

        public async Task<Ebook> UpdateBookAsync(Guid id, EBookUpdateRequest book_info)
        {
            var book = await _eBookRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }

            book_info.UpdateDtoToEBook(book);
            await _eBookRepository.UpdateAsync(book, book_info.AuthorNames, book_info.GenreNames);

            return book;
        }

        public async Task<Ebook> CreateBookAsync(EBookCreateRequest book_info)
        {
            Ebook book = new Ebook();

            book_info.CreateDtoToEBook(book);
            await _authorRepository.CreateMissingAsync(book_info.AuthorNames);
            await _genreRepository.CreateMissingAsync(book_info.GenreNames);
            await _eBookRepository.CreateAsync(book, book_info.AuthorNames, book_info.GenreNames);

            return book;
        }

        public async Task<IEnumerable<EBookGetResponce>> GetAllBooksAsync()
        {
            var ebooks = await _eBookRepository.GetAllAsync();
            var booksDto = ebooks.Select(b => b.EbookToGetResponce());
            return booksDto;

        }

        public async Task<IEnumerable<EBookGetResponce>> GetBooksAsync(string keyword)
        {
            var ebooks = await _eBookRepository.GetBooksAsync(keyword);
            var booksDto = ebooks.Select(b => b.EbookToGetResponce());
            return booksDto;
        }

        public async Task<IEnumerable<EBookGetResponce>> GetBooksByGenreAsync(List<string> genres)
        {
            var ebooks = await _eBookRepository.GetBooksByGenreAsync(genres);
            var booksDto = ebooks.Select(b => b.EbookToGetResponce());
            return booksDto;
        }
    }
}
