using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IEBookRepository: IBookRepository<Ebook>
    {

        Task UpdateAsync(Ebook book, List<string> authorNames, List<string> genreNames);
        Task CreateAsync(Ebook book, List<string> authorNames, List<string> genreNames);
        new Task<IEnumerable<Ebook>> GetAllAsync();
        new Task<IEnumerable<Ebook>> GetBooksAsync(string searchText);
        new Task<IEnumerable<Ebook>> GetBooksByGenreAsync(string genre);

    }
}
