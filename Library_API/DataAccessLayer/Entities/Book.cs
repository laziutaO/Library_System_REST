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
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        public string ISBN { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        
    }
}
