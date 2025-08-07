using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]

        public int TotalSamples { get; set; }

        [NotMapped]
        public int AvailableSamples => TotalSamples - Reservations?.Count(r => !r.IsClosed) ?? 0;

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new();
    }
}
