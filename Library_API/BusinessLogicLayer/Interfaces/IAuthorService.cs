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
        Task<AuthorGetRequest?> GetAuthorAsync(Guid id);

        Task<AuthorGetRequest> CreateAuthorAsync(AuthorCreateRequest author);
        Task<AuthorGetRequest?> UpdateAuthorAsync(Guid id, AuthorUpdateRequest author);
        Task<AuthorGetRequest?> DeleteAuthorAsync(Guid id);
    }
}
