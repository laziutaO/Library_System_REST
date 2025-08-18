using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEbookService: IBookService<Ebook>
    {
        Task<EBookGetResponce?> UpdateBookAsync(Guid id, EBookUpdateRequest book);
        Task<EBookGetResponce> CreateBookAsync(EBookCreateRequest book);
        new Task<IEnumerable<EBookGetResponce>> GetAllBooksAsync();
        new Task<IEnumerable<EBookGetResponce>> GetBooksAsync(string keyword);
        new Task<IEnumerable<EBookGetResponce>> GetBooksByGenreAsync(List<string> genres);
    }
}
