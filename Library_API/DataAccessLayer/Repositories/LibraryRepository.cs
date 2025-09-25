using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LibraryRepository: BaseRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(LibraryDbContext context) : base(context) { }

        public new async Task<IEnumerable<Library>> GetAllAsync()
        {
            var libraries = await libraryDbContext.Libraries
                .Include(b => b.LibraryBooks)
                .ThenInclude(lb => lb.BookCopy)
                .Include(b => b.Schedules)
                .ToListAsync(); 
            
            return libraries;
        }
        public new async Task<Library?> GetAsync(Guid id)
        {
            var library = await libraryDbContext.Libraries
                .Include(b => b.LibraryBooks)
                .ThenInclude(lb => lb.BookCopy)
                .Include(b => b.Schedules)
                .FirstOrDefaultAsync(b => b.Id == id);

            return library == null ? null : library;
        }

        public new async Task CreateAsync(Library library)
        {
            //var bookIds = await libraryDbContext.Books.Where(b => books
            //    .Contains(b.Title))
            //    .Select(b => b.Id)
            //    .ToListAsync();
            //foreach (var bookId in bookIds)
            //{
            //    library.LibraryBooks.Add(new LibraryBook
            //    {
            //        LibraryId = library.Id,
            //        BookCopyId = bookId
            //    });
            //}
            await libraryDbContext.Libraries.AddAsync(library);
            await libraryDbContext.SaveChangesAsync();

            library = await libraryDbContext.Libraries
                .Include(b => b.LibraryBooks)
                .ThenInclude(ba => ba.BookCopy)
                .Include(ba => ba.Schedules)
                .FirstAsync(a => a.Id == library.Id);
        }

        //public async Task UpdateAsync(Library library, List<string> books)
        //{
        //    using var transaction = await libraryDbContext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var bookIds = await libraryDbContext.Books.Where(b => books
        //        .Contains(b.Title))
        //        .Select(b => b.Id)
        //        .ToListAsync();

        //        library.LibraryBooks.Clear();
        //        foreach (var bookId in bookIds)
        //        {
        //            library.LibraryBooks.Add(new LibraryBook
        //            {
        //                LibraryId = library.Id,
        //                BookCopyId = bookId
        //            });
        //        }
        //        await libraryDbContext.SaveChangesAsync();
        //        await transaction.CommitAsync();
        //    }
        //    catch
        //    {
        //        await transaction.RollbackAsync();
        //        throw;

        //    }
        //}
    }
}
