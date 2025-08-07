using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class BookCopy
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }

        public BookStatus Status { get; set; } = BookStatus.Available;
    }
}
