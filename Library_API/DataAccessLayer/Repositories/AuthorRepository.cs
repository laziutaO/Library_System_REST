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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext libraryDbContext): base(libraryDbContext)
        {

        }

        public async Task CreateMissingAsync(List<string> authorNames)
        {
            var oldAuthorsNames = await libraryDbContext.Authors
                .Where(a => authorNames
                .Contains(a.Name))
                .Select(a => a.Name)
                .ToListAsync();
            var newAuthorsNames = authorNames.Except(oldAuthorsNames);

            foreach (var author in newAuthorsNames) 
            {
                await CreateAsync(new Author { Name = author });
            }
        }
        
    }
}
