using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessLayer.Repositories
{
    public class BookRepository<TBook> : BaseRepository<TBook>, IBookRepository<TBook> where TBook : Book
    {
        public BookRepository(LibraryDbContext libraryDbContext): base(libraryDbContext) {}

        public async Task<IEnumerable<TBook>> GetBooksAsync(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return Enumerable.Empty<TBook>();

            IQueryable<TBook> bookQuery = libraryDbContext.Set<TBook>();
            var searchTextNormalized = searchText.Trim().ToLower();

            var author = await libraryDbContext.Authors.FirstOrDefaultAsync(u => u.Name.ToLower() == searchTextNormalized);
            if (author != null)
            {
                var authorId = author.Id;
                bookQuery = bookQuery.Where(b => b.Title.ToLower() == searchTextNormalized || b.BookAuthors.Any(ba => ba.AuthorId == authorId));
            }
            else
            {
                bookQuery = bookQuery.Where(b => b.Title.ToLower() == searchTextNormalized);
            }

            var books = await bookQuery.ToListAsync();
            return books;
        }
        public async Task<IEnumerable<TBook>> GetBooksByGenreAsync(List<string> genres)
        {
            if (genres.IsNullOrEmpty()) return Enumerable.Empty<TBook>();

            IQueryable<TBook> bookQuery = libraryDbContext.Set<TBook>();

            return await bookQuery.Where(book =>
                genres.All(g => book.BookGenres
                .Any(bg => bg.Genre.Name == g)))
                .ToListAsync();
        }

        public async Task<Guid> GetIdAsync(string title)
        {
            var book = await libraryDbContext.Books.FirstOrDefaultAsync(u => u.Title == title);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            return book.Id;
        }

        public async Task<Book> GetAsync(Guid id) 
        {
            var book = await libraryDbContext.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return null;
            return book;
        }
        public async Task UpdateAsync(TBook book)
        {

            await libraryDbContext.SaveChangesAsync();
        }

    }
}
