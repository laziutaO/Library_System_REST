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
    public static class DtoToEBookMapper
    {
        public static void UpdateDtoToEBook(this EBookUpdateRequest bookDto, Ebook ebook)
        {
            ebook.Title = bookDto.Title;
            ebook.ISBN = bookDto.ISBN;
            ebook.Publisher = bookDto.Publisher;
            ebook.Year = bookDto.Year;
            ebook.PagesCount = bookDto.PagesCount;
            ebook.Description = bookDto.Description;
            ebook.CoverImageUrl = bookDto.CoverImageUrl;
            ebook.FileUrl = bookDto.FileUrl;
            ebook.BookAccessType = bookDto.BookAccessType;
        }

        public static void CreateDtoToEBook(this EBookCreateRequest bookDto, Ebook ebook)
        {
            ebook.Title = bookDto.Title;
            ebook.ISBN = bookDto.ISBN;
            ebook.Publisher = bookDto.Publisher;
            ebook.Year = bookDto.Year;
            ebook.PagesCount = bookDto.PagesCount;
            ebook.Description = bookDto.Description;
            ebook.CoverImageUrl = bookDto.CoverImageUrl;
            ebook.FileUrl = bookDto.FileUrl;
            ebook.BookAccessType = bookDto.BookAccessType;
        }
    }
}
