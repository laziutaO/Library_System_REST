using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookRepository: IBaseRepository<Book>
    {
        Task<Guid> GetIdAsync(string title);

        Task<IEnumerable<Book>> GetBooksAsync(string name, string authorName, string category);

        Task UpdateSamplesNumber(Book book);
    }
}
