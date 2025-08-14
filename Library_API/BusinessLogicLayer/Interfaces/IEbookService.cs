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
        Task<Ebook> UpdateBookAsync(Guid id, EBookUpdateRequest book);
    }
}
