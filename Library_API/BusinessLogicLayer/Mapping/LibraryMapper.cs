using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class LibraryMapper
    {
        public static LibraryRequest LibraryToGetDto(this Library library)
        {
            return new LibraryRequest
            {
                Name = library.Name,
                Address = library.Address,
                Phone = library.Phone,
                Books = library.LibraryBooks.Select(lb => lb.BookCopy.Title).ToList()
            };
        }

        public static void DtoToLibrary(this LibraryRequest request, Library library)
        {
            library.Name = request.Name;
            library.Address = request.Address;
            library.Phone = request.Phone;
        }
    }
}
