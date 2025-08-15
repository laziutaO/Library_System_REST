using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class EbookToDto
    {
        public static EBookGetResponce EbookToGetResponce(this Ebook ebook)
        {
            return new EBookGetResponce
            {
                Title = ebook.Title,
                ISBN = ebook.ISBN,
                Publisher = ebook.Publisher,
                Year = ebook.Year,
                PagesCount = ebook.PagesCount,
                Description = ebook.Description,
                CoverImageUrl = ebook.CoverImageUrl,
                FileUrl = ebook.FileUrl,
                BookAccessType = ebook.BookAccessType,
                AuthorNames = ebook.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                GenreNames = ebook.BookGenres.Select(ba => ba.Genre.Name).ToList()
            };
        }
    }
}
