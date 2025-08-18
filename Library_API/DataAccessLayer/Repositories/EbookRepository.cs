using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataAccessLayer.Repositories
{
    public class EbookRepository: BookRepository<Ebook>, IEBookRepository
    {
        public EbookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext) { }
        public async Task<Ebook> GetAsync(Guid id)
        {
            var book = await libraryDbContext.Ebooks
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return null;
            return book;
        }

        public async Task<IEnumerable<Ebook>> GetBooksAsync(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return Enumerable.Empty<Ebook>();

            IQueryable<Ebook> bookQuery = libraryDbContext.Set<Ebook>();
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
                    .ThenInclude(ba => ba.Genre);
            }
            else
            {
                bookQuery = bookQuery.Where(b => b.Title.ToLower() == searchTextNormalized)
                    .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                    .Include(b => b.BookGenres)
                    .ThenInclude(ba => ba.Genre);
            }

            var books = await bookQuery.ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Ebook>> GetBooksByGenreAsync(List<string> genres)
        {
            if (genres == null || !genres.Any()) return Enumerable.Empty<Ebook>();

            IQueryable<Ebook> bookQuery = libraryDbContext.Set<Ebook>();

            return await bookQuery.Where(book =>
                genres.All(g => book.BookGenres
                .Any(bg => bg.Genre.Name == g)))
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ebook>> GetAllAsync()
        {
            List<Ebook> ebooks = await libraryDbContext.Ebooks
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(ba => ba.Genre)
                .ToListAsync();
            if (ebooks == null)
                return null;
            
            return ebooks;
        }

        public async Task UpdateAsync(Ebook book, List<string> authorNames, List<string> genreNames)
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

                await libraryDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            
        }

        public async Task CreateAsync(Ebook book, List<string> authorNames, List<string> genreNames)
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

            await libraryDbContext.Ebooks.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();

            book = await libraryDbContext.Ebooks
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstAsync(b => b.Id == book.Id);
        }

        
    }
}
