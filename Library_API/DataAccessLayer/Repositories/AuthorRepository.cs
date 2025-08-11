using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(LibraryDbContext libraryDbContext): base(libraryDbContext)
        {
        }
        
    }
}
