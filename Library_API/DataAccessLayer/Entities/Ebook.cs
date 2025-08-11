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
    public class Ebook: Book
    {
        public string FileUrl { get; set; } = string.Empty;
        public BookAccessType BookAccessType { get; set; }
    }
}
