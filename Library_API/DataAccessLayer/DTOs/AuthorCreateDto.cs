using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.DTOs
{
    public record struct AuthorCreateDto(string FirstName, string LastName, Author Author);
}
