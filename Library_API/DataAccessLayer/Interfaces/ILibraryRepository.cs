using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILibraryRepository: IBaseRepository<Library>
    {
        public Task CreateAsync(Library library, List<string> books);

        public Task UpdateAsync(Library library, List<string> books);
    }
}
