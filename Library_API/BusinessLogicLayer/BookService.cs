﻿using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTOs;
using DataAccessLayer.Data;

namespace BusinessLogicLayer
{
    public class BookService: IBookService
    {
        public readonly IBookRepository _repository;
        public readonly IBaseRepository<Author> _authorRepository;
        public BookService (IBookRepository repository, IBaseRepository<Author> authorRepository) 
        { 
            _repository = repository;
            _authorRepository = authorRepository;
        }

        public async Task CreateBookAsync(Book book)
        {
            await _repository.CreateAsync(book);
        }

        public async Task<Book> DeleteBookAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);

            if (book == null)
            {
                return null;
            }

            await _repository.DeleteAsync(book);

            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(string name, string author, string category)
        {
            return await _repository.GetBooksAsync(name, author, category);
        }
        public async Task<Book> UpdateBookAsync(Guid id, BookUpdateDto book_info)
        {
            var book = await _repository.GetAsync(id);
           
            if (book == null)
            {
                return null;
            }

            book.Title = book_info.Title;
            book.Category = book_info.Category;
            book.AvailableSamples = book_info.AvailableSamples;
      

            await _repository.UpdateAsync();

            return book;
        }

        
    }
}
