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
        public Guid Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }
    }
}
