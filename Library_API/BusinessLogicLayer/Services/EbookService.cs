using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EbookService : BookService<Ebook>
    {
        private readonly IEBookRepository eBookRepository;
        public EbookService(IEBookRepository repository, IBaseRepository<Author> authorRepository) : base(repository, authorRepository)
        {
            eBookRepository = repository;
        }

        public async Task<Ebook> UpdateBookAsync(Guid id, EBookUpdateRequest book_info)
        {
            var book = await eBookRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }

            book_info.UpdateDtoToEBook(book);
            await eBookRepository.UpdateAsync(book, book_info.AuthorNames, book_info.GenreNames);

            return book;
        }
    }
}
