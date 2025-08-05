using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> GetAuthorAsync(Guid id);

        Task CreateAuthorAsync(AuthorUpdateRequest author);
        Task<Author> UpdateAuthorAsync(Guid id, AuthorUpdateRequest author);
        Task<Author> DeleteAuthorAsync(Guid id);
    }
}
