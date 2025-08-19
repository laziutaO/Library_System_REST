using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAuthorRepository: IBaseRepository<Author>
    {
        public Task CreateMissingAsync(List<string> authorNames);
        public Task CreateAsync(Author author, List<string> books);

        public Task UpdateAsync(Author author, List<string> books);
    }
}
