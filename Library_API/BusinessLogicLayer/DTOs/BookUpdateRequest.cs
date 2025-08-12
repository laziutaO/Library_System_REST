using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct BookUpdateRequest(string Title,
        string ISBN,
        string Publisher,
        int Year,
        int PagesCount,
        string Description,
        string CoverImageUrl,
        List<Guid> AuthorIds,
        List<Guid> GenreIds,
        List<Guid> LibraryIds);
    
}
