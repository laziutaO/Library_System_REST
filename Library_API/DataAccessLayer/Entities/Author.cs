using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

    }
}
