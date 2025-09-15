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
        public static BookCopyGetRequest BookCopyToGetDto(this BookCopy bookCopy)
        {
            return new (
                bookCopy.Id.ToString(),
                bookCopy.Title,
                bookCopy.ISBN,
                bookCopy.Publisher,
                bookCopy.Year,
                bookCopy.PagesCount,
                bookCopy.Description,
                bookCopy.CoverImageUrl,
                bookCopy.Status,
                bookCopy.BookAuthors.Select(bC => bC.Author.Name).ToList(),
                bookCopy.BookGenres.Select(bC => bC.Genre.Name).ToList(),
                bookCopy.LibraryBooks.Select(bC => bC.Library.Name).ToList());
        }

        public static void CreateRequestToBookCopy(this BookCopyCreateRequest request, BookCopy book)
        {
            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.Publisher = request.Publisher;
            book.Year = request.Year;
            book.PagesCount = request.PagesCount;
            book.Description = request.Description;
            book.CoverImageUrl = request.CoverImageUrl;
            book.Status = request.Status;
        }

        public static void UpdateRequestToBookCopy(this BookCopyUpdateRequest request, BookCopy book)
        {
            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.Publisher = request.Publisher;
            book.Year = request.Year;
            book.PagesCount = request.PagesCount;
            book.Description = request.Description;
            book.CoverImageUrl = request.CoverImageUrl;
            book.Status = request.Status;
        }
    }
}
