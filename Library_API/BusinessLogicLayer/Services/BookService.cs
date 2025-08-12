using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;


namespace BusinessLogicLayer.Services
{
    public class BookService<TBook>: IBookService<TBook> where TBook : Book
    {
        public readonly IBookRepository<TBook> _repository;
        public readonly IBaseRepository<Author> _authorRepository;
        public BookService (IBookRepository<TBook> repository, IBaseRepository<Author> authorRepository) 
        { 
            _repository = repository;
            _authorRepository = authorRepository;
        }

        public async Task CreateBookAsync(TBook book)
        {
            await _repository.CreateAsync(book);
        }

        public async Task<TBook> DeleteBookAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);

            if (book == null)
            {
                return null;
            }

            await _repository.DeleteAsync(book);

            return book;
        }

        public async Task<IEnumerable<TBook>> GetAllBooksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TBook> GetBookAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<TBook>> GetBooksAsync(string name)
        {
            return await _repository.GetBooksAsync(name);
        }
        public async Task<TBook> UpdateBookAsync(Guid id, BookUpdateRequest book_info)
        {
            var book = await _repository.GetAsync(id);
           
            if (book == null)
            {
                return null;
            }

            book.Title = book_info.Title;
            await _repository.UpdateAsync();

            return book;
        }

        
    }
}
