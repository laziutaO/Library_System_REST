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
            return new(
                library.Id.ToString(),
                library.Description,
                library.CoverImageUrl,
                library.Name,
                library.Address,
                library.Phone,
                library.LibraryBooks.Select(lb => lb.BookCopy?.Title ?? string.Empty).ToList());
        }

        public static void DtoToLibrary(this LibraryRequest request, Library library)
        {
            library.Name = request.name;
            library.Address = request.address;
            library.Phone = request.phone;
            library.Description = request.description;
            library.CoverImageUrl = request.coverImageUrl;
        }
    }
}
