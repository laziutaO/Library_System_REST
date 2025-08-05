using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly IBaseRepository<Author> _repository;
        public AuthorService(IBaseRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task CreateAuthorAsync(AuthorUpdateRequest author)
        {
            Author new_author = new Author();
            new_author.FirstName = author.FirstName;
            new_author.LastName = author.LastName;
            await _repository.CreateAsync(new_author);
        }

        public async Task<Author> DeleteAuthorAsync(Guid id)
        {
            var author = await _repository.GetAsync(id);

            if (author == null)
            {
                return null;
            }

            await _repository.DeleteAsync(author);

            return author;
        }

        public async Task<Author> GetAuthorAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Author> UpdateAuthorAsync(Guid id, AuthorUpdateRequest author_info)
        {
            var author = await _repository.GetAsync(id);

            if (author == null)
            {
                return null;
            }

            author.FirstName = author_info.FirstName;
            author.LastName = author_info.LastName;

            await _repository.UpdateAsync();

            return author;
        }

    }
}
