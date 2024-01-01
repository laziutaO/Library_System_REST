using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        public string Category { get; set; }
        public int AvailableSamples { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; }
    }
}
