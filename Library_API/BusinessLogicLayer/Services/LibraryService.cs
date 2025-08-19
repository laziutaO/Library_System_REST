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
        public async Task<LibraryRequest> CreateLibraryAsync(LibraryRequest library)
        {
            Library new_library = new Library();
            library.DtoToLibrary(new_library);
            await _repository.CreateAsync(new_library, library.Books);
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

        public async Task<LibraryRequest?> GetLibraryAsync(Guid id)
        {
            var library = await _repository.GetAsync(id);
            return library == null ? null : library.LibraryToGetDto();
        }

        public async Task<LibraryRequest?> UpdateLibraryAsync(Guid id, LibraryRequest library_info)
        {
            var library = await _repository.GetAsync(id);

            if (library == null)
            {
                return null;
            }

            library_info.DtoToLibrary(library);

            await _repository.UpdateAsync(library, library_info.Books);

            return library.LibraryToGetDto();
        }
    }
}
