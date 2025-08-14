using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IEBookRepository: IBookRepository<Ebook>
    {

        Task UpdateAsync(Ebook book, List<string> authorNames, List<string> genreNames);
    }
}
