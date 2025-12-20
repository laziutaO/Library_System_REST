using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public Guid BookId { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateOnly PostedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        public Book Book { get; set; }
    }
}
