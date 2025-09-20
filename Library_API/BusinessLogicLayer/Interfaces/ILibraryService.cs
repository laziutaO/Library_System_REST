
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILibraryService
    {
        Task<IEnumerable<LibraryRequest>> GetLibrariesAsync();
        Task<LibraryRequest?> GetLibraryAsync(Guid id);

        Task<LibraryRequest> CreateLibraryAsync(LibraryRequest author);
        Task<LibraryRequest?> UpdateLibraryAsync(Guid id, LibraryRequest author);
        Task<LibraryRequest?> DeleteLibraryAsync(Guid id);
    }
}