using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBookService<TBook> where TBook : Book
    {
        Task<IEnumerable<TBook>> GetAllBooksAsync();
        Task<TBook?> GetBookAsync(Guid id);
        Task<IEnumerable<TBook>> GetBooksByGenreAsync(string genre);

        Task CreateBookAsync(TBook book);
        Task<TBook?> DeleteBookAsync(Guid id);
        Task<IEnumerable<TBook>> GetBooksAsync(string name);
    }
}
