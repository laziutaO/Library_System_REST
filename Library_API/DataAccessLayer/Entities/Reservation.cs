using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookCopyId { get; set; }
        public DateOnly ReserveDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly ExpiresAt { get; set; }
        public bool IsClosed { get; set; }

    }
}
