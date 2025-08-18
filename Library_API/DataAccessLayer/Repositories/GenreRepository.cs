using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenreRepository: BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext) 
        {
        
        }
        public async Task CreateMissingAsync(List<string> genresNames)
        {
            var oldGenresNames = await libraryDbContext.Genres.Where(g => genresNames.Contains(g.Name)).Select(g => g.Name).ToListAsync();
            var newGenresNames = genresNames.Except(oldGenresNames);
           
            foreach (var genreName in newGenresNames)
            {
                await CreateAsync(new Genre { Name = genreName });
            }
        }
    }
}
