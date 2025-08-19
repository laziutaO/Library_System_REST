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
            return new BookCopyGetRequest()
            {
                Title = bookCopy.Title,
                ISBN = bookCopy.ISBN,
                Publisher = bookCopy.Publisher,
                Year = bookCopy.Year,
                PagesCount = bookCopy.PagesCount,
                Description = bookCopy.Description,
                CoverImageUrl = bookCopy.CoverImageUrl,
                TotalSamples = bookCopy.TotalSamples,
                AuthorIds = bookCopy.BookAuthors.Select(bC => bC.AuthorId).ToList(),
                GenreIds = bookCopy.BookGenres.Select(bC => bC.GenreId).ToList(),
                LibraryIds = bookCopy.LibraryBooks.Select(bC => bC.LibraryId).ToList()
            };
        }
    }
}
