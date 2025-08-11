using DataAccessLayer.Enums;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Ebook
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public BookAccessType BookAccessType { get; set; }
    }
}
