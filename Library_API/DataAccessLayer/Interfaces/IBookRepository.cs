using DataAccessLayer.Entities;
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
    }
}
