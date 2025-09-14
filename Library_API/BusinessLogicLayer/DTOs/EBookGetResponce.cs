using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record EBookGetResponce(
        string id,
        string title,
        string isbn,
        string publisher,
        int year,
        int pagesCount,
        string description,
        string coverImageUrl,
        string fileUrl,
        BookAccessType bookAccessType,
        List<string> authorNames,
        List<string> genreNames);

}
