using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class BookCopyMapper
    {
        public static BookCopyGetRequest GetBookCopyToDto(this BookCopy bookCopy)
        {
            return new (
                bookCopy.Title,
                bookCopy.ISBN,
                bookCopy.Publisher,
                bookCopy.Year,
                bookCopy.PagesCount,
                bookCopy.Description,
                bookCopy.CoverImageUrl,
                bookCopy.Status,
                bookCopy.BookAuthors.Select(bC => bC.AuthorId).ToList(),
                bookCopy.BookGenres.Select(bC => bC.GenreId).ToList(),
                bookCopy.LibraryBooks.Select(bC => bC.LibraryId).ToList());
        }
    }
}
