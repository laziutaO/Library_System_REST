using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookCopyId { get; set; }
        public Guid LibraryId { get; set; }
        public DateOnly ReserveDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly ExpiresAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(14);
        public bool IsClosed { get; set; } = false;


       
        public BookCopy BookCopy { get; set; } = null!;

    }
}
