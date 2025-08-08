using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class LibraryBook
    {
        public Guid Id { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; } = null!;
        public Guid BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; } = null!;
    }
}
