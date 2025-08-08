using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BookGenre
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
