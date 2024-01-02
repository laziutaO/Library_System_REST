using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessLayer.Interfaces
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task CreateAsync(Book entity)
        {
            entity.Id = Guid.NewGuid();
            await _libraryDbContext.Books.AddAsync(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book entity)
        {
            _libraryDbContext.Books.Remove(entity);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _libraryDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(u => u.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(string name, string authorName, string category)
        {
            IQueryable<Book> bookQuery = _libraryDbContext.Books;

            if (!string.IsNullOrWhiteSpace(name))
            {
                bookQuery = bookQuery.Where(u => u.Title == name);
            }

            if (!string.IsNullOrWhiteSpace(authorName))
            {
                var author = await _libraryDbContext.Authors.FirstOrDefaultAsync(u => u.LastName == authorName);
                if (author != null)
                {
                    var authorId = author.Id;
                    bookQuery = bookQuery.Where(u => u.AuthorId == authorId);
                }
                else
                {
                    return Enumerable.Empty<Book>();
                }
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                bookQuery = bookQuery.Where(u => u.Category == category);
            }

            var books = await bookQuery.ToListAsync();
            return books;
        }

        public async Task UpdateAsync()
        {
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<Guid> GetIdAsync(string title)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(u => u.Title == title);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            return book.Id;
        }
    }
}
