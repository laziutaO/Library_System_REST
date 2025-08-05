using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public record struct AuthorCreateRequest(string FirstName, string LastName);
}
