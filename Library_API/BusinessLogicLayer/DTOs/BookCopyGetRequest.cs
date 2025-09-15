using DataAccessLayer.Entities;
using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record BookCopyGetRequest(
        string id,
        string title,
        string isbn,
        string publisher,
        int year,
        int pagesCount,
        string description,
        string coverImageUrl,
        BookStatus status,
        List<string> authorNames,
        List<string> genreNames,
        List<string> libraryNames);
}
