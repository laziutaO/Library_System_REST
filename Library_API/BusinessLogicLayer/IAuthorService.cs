using DataAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IAuthorService
    {
        Task<Author> GetAuthorAsync(Guid id);

        Task CreateAuthorAsync(AuthorUpdateDto author);
        Task<Author> UpdateAuthorAsync(Guid id, AuthorUpdateDto author);
        Task<Author> DeleteAuthorAsync(Guid id);
    }
}
