using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);

        Task CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Guid id, BookUpdateRequest book);
        Task<Book> DeleteBookAsync(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync(string name, string author, string category);
    }
}
