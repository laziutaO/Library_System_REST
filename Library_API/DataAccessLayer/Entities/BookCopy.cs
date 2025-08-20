using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BookCopy: Book
    {
        public BookStatus Status { get; set; } = BookStatus.Available;
        public ICollection<LibraryBook> LibraryBooks { get; set; } = null!;
    }
}
