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
        }
    }
}
