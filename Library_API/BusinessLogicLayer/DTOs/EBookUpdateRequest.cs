using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct EBookUpdateRequest(string Title,
        string ISBN,
        string Publisher,
        int Year,
        int PagesCount,
        string Description,
        string CoverImageUrl,
        string FileUrl,
        BookAccessType BookAccessType,
        List<string> AuthorNames,
        List<string> GenreNames);
}
