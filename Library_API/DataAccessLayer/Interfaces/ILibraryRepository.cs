using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILibraryRepository: IBaseRepository<Library>
    {
        public new Task CreateAsync(Library library);
        public Task<Library?> GetByIdAsync(Guid id);

        public Task<BookCopy?> AddBookToLibraryAsync(Library library, Guid bookId);
        public Task<LibraryBook?> RemoveBookFromLibraryAsync(Library library, Guid bookId);
    }
}
