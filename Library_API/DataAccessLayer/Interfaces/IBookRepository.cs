using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookRepository<TBook> : IBaseRepository<TBook> where TBook : Book
    {
        Task<Guid> GetIdAsync(string title);

        Task<IEnumerable<TBook>> GetBooksAsync(string searchText);

    }
}
