using Azure.Core;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public class DtoToBookMapper
    {
        public Book UpdateDtoToBook(BookUpdateRequest bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                Publisher = bookDto.Publisher,
                Year = bookDto.Year,
                PagesCount = bookDto.PagesCount,
                Description = bookDto.Description,
                CoverImageUrl = bookDto.CoverImageUrl,
                BookAuthors = bookDto.AuthorIds.Select(authorId => new BookAuthor
                {
                    AuthorId = authorId
                }).ToList(),
                BookGenres = bookDto.GenreIds.Select(genreId => new BookGenre
                {
                    GenreId = genreId
                }).ToList(),
            };
        }
    }
}
