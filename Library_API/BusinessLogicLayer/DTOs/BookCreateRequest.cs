using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct BookCreateRequest(string Title, string Category, int TotalSamples, AuthorCreateRequest Author);
    
}
