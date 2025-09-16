using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreGetResponce>> GetGenreResponcesAsync();
        Task<GenreGetResponce?> GetGenreAsync(Guid id);

        Task<GenreGetResponce> CreateGenreAsync(GenreCreateRequest author);
        Task<GenreGetResponce?> UpdateGenreAsync(Guid id, GenreUpdateRequest author);
        Task<GenreGetResponce?> DeleteGenreAsync(Guid id);
    }
}
