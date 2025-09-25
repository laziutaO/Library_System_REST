
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILibraryService
    {
        Task<IEnumerable<LibraryRequest>> GetLibrariesAsync();
        Task<LibraryRequest?> GetLibraryAsync(Guid id);

        Task<LibraryRequest> CreateLibraryAsync(LibraryCreateRequest libraryRequest);
        Task<LibraryRequest?> UpdateLibraryAsync(Guid id, LibraryUpdateRequest libraryRequest);
        Task<LibraryRequest?> DeleteLibraryAsync(Guid id);

        Task<BookCopyGetRequest?> AddBookToLibrary(Guid libraryId, string bookId);

        Task<LibraryBook?> RemoveBookToLibrary(Guid libraryId, string bookId);
    }
}