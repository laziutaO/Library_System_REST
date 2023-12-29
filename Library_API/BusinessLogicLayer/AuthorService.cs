using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class AuthorService : IAuthorService
    {
        public readonly IBaseRepository<Author> _repository;
        public AuthorService(IBaseRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _repository.CreateAsync(author);
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

        public async Task<Author> UpdateAuthorAsync(Guid id, Author author_info)
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
