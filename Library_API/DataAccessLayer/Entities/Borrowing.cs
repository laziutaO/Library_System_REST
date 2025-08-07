using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Borrowing
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookCopyId { get; set; }
        public DateOnly BorrowedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly DueDate { get; set; }
        public DateOnly ReturnedAt { get; set; }
        public bool IsOverdue { get; set; }

    }
}
