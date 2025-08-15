using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BookCopyService : BookService<BookCopy>
    {
        public BookCopyService(IBookRepository<BookCopy> repository) : base(repository)
        {
        }
    }
}
