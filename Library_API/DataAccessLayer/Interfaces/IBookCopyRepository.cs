using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookCopyRepository: IBookRepository<BookCopy>
    {
        Task UpdateAsync(BookCopy book, List<string> authorNames, List<string> genreNames, List<string> libraryNames);
        Task CreateAsync(BookCopy book, List<string> authorNames, List<string> genreNames, List<string> libraryNames);
        new Task<IEnumerable<BookCopy>> GetAllAsync();
        new Task<IEnumerable<BookCopy>> GetBooksAsync(string searchText);
        new Task<IEnumerable<BookCopy>> GetBooksByGenreAsync(List<string> genres);
    }
}
