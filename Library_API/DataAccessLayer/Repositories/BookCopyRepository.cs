using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookCopyRepository: BookRepository<BookCopy>, IBookCopyRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
       
        public BookCopyRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public new async Task<BookCopy?> GetAsync(Guid id)
        {
            var book = await _libraryDbContext.BookCopies
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .Include(b => b.LibraryBooks)
                .ThenInclude(lb => lb.Library)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return null;
            return book;
        }

        public async Task CreateAsync(BookCopy book, List<string> authorNames, List<string> genreNames, List<string> libraryNames)
        {
            var authorIds = await libraryDbContext.Authors
                    .Where(author => authorNames
                    .Contains(author.Name))
                    .Select(a => a.Id)
                    .ToListAsync();

            var genreIds = await libraryDbContext.Genres
                .Where(genre => genreNames
                .Contains(genre.Name))
                .Select(g => g.Id)
                .ToListAsync();

            var libraryIds = await libraryDbContext.Libraries
                .Where(library => libraryNames
                .Contains(library.Name))
                .Select(l => l.Id)
                .ToListAsync();

            foreach (var authorId in authorIds)
            {
                book.BookAuthors.Add(new BookAuthor
                {
                    AuthorId = authorId,
                    BookId = book.Id
                });
            }

            foreach (var genreId in genreIds)
            {
                book.BookGenres.Add(new BookGenre
                {
                    GenreId = genreId,
                    BookId = book.Id
                });
            }

            foreach (var libraryId in libraryIds)
            {
                book.LibraryBooks.Add(new LibraryBook
                {
                    LibraryId = libraryId,
                    BookCopyId = book.Id
                });
            }

            await libraryDbContext.BookCopies.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();

            book = await libraryDbContext.BookCopies
               .Include(b => b.BookAuthors)
               .ThenInclude(ba => ba.Author)
               .Include(b => b.BookGenres)
               .ThenInclude(bg => bg.Genre)
               .Include(b => b.LibraryBooks)
               .ThenInclude(lb => lb.Library)
               .FirstAsync(b => b.Id == book.Id);
        }

        public async Task UpdateAsync(BookCopy book, List<string> authorNames, List<string> genreNames, List<string> libraryNames)
        {
            using var transaction = await libraryDbContext.Database.BeginTransactionAsync();
            try
            {
                var authorIds = await libraryDbContext.Authors
                    .Where(author => authorNames
                    .Contains(author.Name))
                    .Select(a => a.Id)
                    .ToListAsync();

                var genreIds = await libraryDbContext.Genres
                    .Where(genre => genreNames
                    .Contains(genre.Name))
                    .Select(g => g.Id)
                    .ToListAsync();

                var libraryIds = await libraryDbContext.Libraries
                    .Where(library => libraryNames
                    .Contains(library.Name))
                    .Select(l => l.Id)
                    .ToListAsync();

                book.BookAuthors.Clear();
                foreach (var authorId in authorIds)
                {
                    book.BookAuthors.Add(new BookAuthor
                    {
                        AuthorId = authorId,
                        BookId = book.Id
                    });
                }
                book.BookGenres.Clear();
                foreach (var genreId in genreIds)
                {
                    book.BookGenres.Add(new BookGenre
                    {
                        GenreId = genreId,
                        BookId = book.Id
                    });
                }
                book.LibraryBooks.Clear();
                foreach (var libraryId in libraryIds)
                {
                    book.LibraryBooks.Add(new LibraryBook
                    {
                        LibraryId = libraryId,
                        BookCopyId = book.Id
                    });
                }
                var id = book.Id;
                await libraryDbContext.SaveChangesAsync();
                book = await libraryDbContext.BookCopies.Where(b => b.Id == id)
               .Include(b => b.BookAuthors)
               .ThenInclude(ba => ba.Author)
               .Include(b => b.BookGenres)
               .ThenInclude(ba => ba.Genre)
               .Include(b => b.LibraryBooks)
               .ThenInclude(lb => lb.Library).FirstAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async new Task<IEnumerable<BookCopy>?> GetAllAsync()
        {
            List<BookCopy> books = await libraryDbContext.BookCopies
               .Include(b => b.BookAuthors)
               .ThenInclude(ba => ba.Author)
               .Include(b => b.BookGenres)
               .ThenInclude(ba => ba.Genre)
               .Include(b => b.LibraryBooks)
               .ThenInclude(lb => lb.Library)
               .ToListAsync();
            if (books == null)
                return null;

            return books;
        }
        public async new Task<IEnumerable<BookCopy>> GetBooksAsync(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return Enumerable.Empty<BookCopy>();

            IQueryable<BookCopy> bookQuery = libraryDbContext.Set<BookCopy>();
            var searchTextNormalized = searchText.Trim().ToLower();

            var author = await libraryDbContext.Authors.FirstOrDefaultAsync(u => u.Name.ToLower() == searchTextNormalized);
            if (author != null)
            {
                var authorId = author.Id;
                bookQuery = bookQuery
                    .Where(b => b.Title.ToLower() == searchTextNormalized ||
                    b.BookAuthors.Any(ba => ba.AuthorId == authorId))
                    .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                    .Include(b => b.BookGenres)
                    .ThenInclude(ba => ba.Genre)
                    .Include(b => b.LibraryBooks)
                    .ThenInclude(lb => lb.Library);
            }
            else
            {
                bookQuery = bookQuery.Where(b => b.Title.ToLower() == searchTextNormalized)
                    .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                    .Include(b => b.BookGenres)
                    .ThenInclude(ba => ba.Genre)
                    .Include(b => b.LibraryBooks)
                    .ThenInclude(lb => lb.Library);
            }

            var books = await bookQuery.ToListAsync();
            return books;
        }
        public async new Task<IEnumerable<BookCopy>> GetBooksByGenreAsync(string genreName)
        {
            if (genreName == null) return Enumerable.Empty<BookCopy>();

            IQueryable<BookCopy> bookQuery = libraryDbContext.Set<BookCopy>();

            return await bookQuery.Where(book =>book.BookGenres
                .Any(bg => bg.Genre.Name == genreName))
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .Include(b => b.LibraryBooks)
                .ThenInclude(lb => lb.Library)
                .ToListAsync();
        }
    }
}
