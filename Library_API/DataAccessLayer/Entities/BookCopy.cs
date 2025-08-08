using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BookCopy
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public int TotalSamples { get; set; }

        //[NotMapped]
        //public int AvailableSamples => TotalSamples - Reservations?.Count(r => !r.IsClosed) ?? 0;
        public BookStatus Status { get; set; } = BookStatus.Available;
    }
}
