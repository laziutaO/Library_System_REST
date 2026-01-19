using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;
        public LibraryService(ILibraryRepository repository) 
        {
            _repository = repository;
        }

        public async Task<BookCopyGetRequest?> AddBookToLibrary(Guid libraryId, BookIdDto bookRequest)
        {
            var library = await _repository.GetByIdAsync(libraryId);
            if (library == null)
            {
                return null;
            }

            BookCopy? book;
           
            book = await _repository.AddBookToLibraryAsync(library, bookRequest.bookId);
            if (book == null)
            {
                return null;
            }
            return book.BookCopyToGetDto();
        }

        public async Task<LibraryRequest> CreateLibraryAsync(LibraryCreateRequest library)
        {
            Library new_library = library.CreateDtoToLibrary();
            await _repository.CreateAsync(new_library);
            return new_library.LibraryToGetDto();
        }

        public async Task<LibraryRequest?> DeleteLibraryAsync(Guid id)
        {
            var library = await _repository.GetAsync(id);
            if (library == null) 
            {
                return null;
            }
            await _repository.DeleteAsync(library);
            return library.LibraryToGetDto();
        }

        public async Task<IEnumerable<LibraryRequest>> GetLibrariesAsync()
        {
            var libraries = await _repository.GetAllAsync();
            var libraryResponce = libraries.Select(l => l.LibraryToGetDto()).ToList();
            return libraryResponce;
        }

        public async Task<LibraryRequest?> GetLibraryAsync(Guid id)
        {
            var library = await _repository.GetAsync(id);
            return library == null ? null : library.LibraryToGetDto();
        }

        public async Task<LibraryBook?> RemoveBookToLibrary(Guid libraryId, string bookId)
        {
            var library = await _repository.GetByIdAsync(libraryId);

            if (library == null)
            {
                return null;
            }
            LibraryBook? librarybook;
            if (Guid.TryParse(bookId, out Guid bookIdParse))
            {
                librarybook = await _repository.RemoveBookFromLibraryAsync(library, bookIdParse);
            }
            else
            {
                return null;
            }
            if (librarybook == null)
            {
                return null;
            }
            return librarybook;
        }

        public async Task<LibraryRequest?> UpdateLibraryAsync(Guid id, LibraryUpdateRequest library_info)
        {
            var library = await _repository.GetAsync(id);

            if (library == null)
            {
                return null;
            }

            library_info.UpdateDtoToLibrary(library);
            await _repository.UpdateAsync();
            return library.LibraryToGetDto();
        }
    }
}
