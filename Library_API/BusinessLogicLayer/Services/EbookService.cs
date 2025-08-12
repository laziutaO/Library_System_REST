using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EbookService : BookService<Ebook>
    {
        public EbookService(IBookRepository<Ebook> repository, IBaseRepository<Author> authorRepository) : base(repository, authorRepository)
        {
        }
    }
}
