using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository) 
        {
            _genreRepository = genreRepository;
        }  

        public async Task<GenreGetResponce> CreateGenreAsync(GenreCreateRequest genre)
        {
            Genre new_genre = new Genre();
            new_genre.Name = genre.name;
            await _genreRepository.CreateAsync(new_genre);
            return new GenreGetResponce(new_genre.Id.ToString(), new_genre.Name);
        }

        public async Task<GenreGetResponce?> DeleteGenreAsync(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre == null)
            {
                return null;
            }
            await _genreRepository.DeleteAsync(genre);
            return new GenreGetResponce(id.ToString(), genre.Name);
        }

        public async Task<GenreGetResponce?> GetGenreAsync(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre == null)
            {
                return null;
            }
            return new GenreGetResponce(genre.Id.ToString(), genre.Name);
        }

        public async Task<IEnumerable<GenreGetResponce>> GetGenreResponcesAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            var genreResponce = genres.Select(b => new GenreGetResponce(b.Id.ToString(), b.Name));
            return genreResponce;
        }

        public async Task<GenreGetResponce?> UpdateGenreAsync(Guid id, GenreUpdateRequest genreRequest)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre == null)
            {
                return null;
            }
            genre.Name = genreRequest.name;
            await _genreRepository.UpdateAsync();
            return new GenreGetResponce(genre.Id.ToString(), genre.Name);
        }
    }
}
