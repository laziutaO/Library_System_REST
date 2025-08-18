using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
