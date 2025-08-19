using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext libraryDbContext): base(libraryDbContext)
        {

        }
        public new async Task<Author?> GetAsync(Guid id)
        {
            var author = await libraryDbContext.Authors
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(b => b.Id == id);

            return author == null ? null : author;
        }

        public async Task CreateAsync(Author entity, List<string> booksTitles)
        {
            var bookIds = await libraryDbContext.Books.Where(b => booksTitles
                .Contains(b.Title))
                .Select(b => b.Id)
                .ToListAsync();
            foreach(var bookId in bookIds)
            {
                entity.BookAuthors.Add(new BookAuthor
                {
                    AuthorId = entity.Id,
                    BookId = bookId
                });
            }
            await libraryDbContext.Authors.AddAsync(entity);
            await libraryDbContext.SaveChangesAsync();

            entity = await libraryDbContext.Authors
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstAsync(a => a.Id == entity.Id);
        }
        public async Task CreateMissingAsync(List<string> authorNames)
        {
            var oldAuthorsNames = await libraryDbContext.Authors
                .Where(a => authorNames
                .Contains(a.Name))
                .Select(a => a.Name)
                .ToListAsync();
            var newAuthorsNames = authorNames.Except(oldAuthorsNames);

            foreach (var author in newAuthorsNames) 
            {
                await CreateAsync(new Author { Name = author });
            }
        }

        public async Task UpdateAsync(Author author, List<string> booksTitles)
        {
            using var transaction = await libraryDbContext.Database.BeginTransactionAsync();
            try
            {
                var bookIds = await libraryDbContext.Books.Where(b => booksTitles
                .Contains(b.Title))
                .Select(b => b.Id)
                .ToListAsync();

                author.BookAuthors.Clear();
                foreach (var bookId in bookIds)
                {
                    author.BookAuthors.Add(new BookAuthor
                    {
                        AuthorId = author.Id,
                        BookId = bookId
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
    }
}
