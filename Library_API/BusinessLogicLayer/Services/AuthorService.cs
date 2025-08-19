using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorGetRequest> CreateAuthorAsync(AuthorCreateRequest author)
        {
            Author new_author = new Author();
            new_author.Name = author.name;
            await _repository.CreateAsync(new_author, author.books);
            return new_author.AuthorToGetDto();
        }

        public async Task<AuthorGetRequest?> DeleteAuthorAsync(Guid id)
        {
            var author = await _repository.GetAsync(id);

            if (author == null)
            {
                return null;
            }

            await _repository.DeleteAsync(author);

            return author.AuthorToGetDto();
        }

        public async Task<AuthorGetRequest?> GetAuthorAsync(Guid id)
        {
            var author = await _repository.GetAsync(id);
            return author == null ? null : author.AuthorToGetDto();
        }

        public async Task<AuthorGetRequest?> UpdateAuthorAsync(Guid id, AuthorUpdateRequest author_info)
        {
            var author = await _repository.GetAsync(id);

            if (author == null)
            {
                return null;
            }

            author.Name = author_info.name;

            await _repository.UpdateAsync(author, author_info.books);

            return author.AuthorToGetDto();
        }

    }
}
