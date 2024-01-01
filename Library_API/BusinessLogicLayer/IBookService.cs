using DataAccessLayer.Entities;
using DataAccessLayer.DTOs;
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

        Task CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Guid id, BookUpdateDto book);
        Task<Book> DeleteBookAsync(Guid id);
    }
}
