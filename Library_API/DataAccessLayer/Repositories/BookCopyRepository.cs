using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookCopyRepository: BookRepository<BookCopy>, IBookCopyRepository
    {
        public BookCopyRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
       
    }
}
