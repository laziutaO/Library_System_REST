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
           return new (
                ebook.Title,
                ebook.ISBN,
                ebook.Publisher,
                ebook.Year,
                ebook.PagesCount,
                ebook.Description,
                ebook.CoverImageUrl,
                ebook.FileUrl,
                ebook.BookAccessType,
                ebook.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                ebook.BookGenres.Select(ba => ba.Genre.Name).ToList())
            ;
        }
    }
}
