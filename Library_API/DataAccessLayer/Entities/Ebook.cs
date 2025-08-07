using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Ebook
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public BookAccessType BookAccessType { get; set; }
    }
}
