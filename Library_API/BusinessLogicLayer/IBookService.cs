using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);

        Task CreateBookAsync(Book book, Guid authorId);
        Task<Book> UpdateBookAsync(Guid id, Book book);
        Task<Book> DeleteBookAsync(Guid id);
    }
}
