using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBookCopyService: IBookService<BookCopy>
    {
        Task<BookCopyGetRequest?> UpdateBookAsync(Guid id, BookCopyUpdateRequest book);
        Task<BookCopyGetRequest> CreateBookAsync(BookCopyCreateRequest book);
        new Task<IEnumerable<BookCopyGetRequest>> GetAllBooksAsync();
        new Task<IEnumerable<BookCopyGetRequest>> GetBooksAsync(string keyword);
        new Task<IEnumerable<BookCopyGetRequest>> GetBooksByGenreAsync(string genre);
    }
}
