using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repositories
{
    public class EbookRepository: BookRepository<Ebook>, IEBookRepository
    {
        public EbookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext) { }
    }
}
