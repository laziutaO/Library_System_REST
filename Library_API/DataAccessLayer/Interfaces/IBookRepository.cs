using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book> GetAsync(Guid id);

        Task CreateAsync(Book entity);
        Task UpdateAsync();
        Task DeleteAsync(Book entity);

        Task<Guid> GetIdAsync(string title);

        Task<IEnumerable<Book>> GetBooksAsync(string name, string authorName, string category);

        Task UpdateSamplesNumber(Book book);
    }
}
