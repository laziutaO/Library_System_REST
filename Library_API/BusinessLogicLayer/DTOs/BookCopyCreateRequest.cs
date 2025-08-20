using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record BookCopyCreateRequest(string Title,
        string ISBN,
        string Publisher,
        int Year,
        int PagesCount,
        string Description,
        string CoverImageUrl,
        BookStatus Status,
        List<string> AuthorNames,
        List<string> GenreNames,
        List<string> LibraryNames);
}
