using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Library
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public string Address { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Invalid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int StudyRooms { get; set; }
        public int Computers { get; set; }

        public ICollection<LibrarySchedule> Schedules { get; set; } = new List<LibrarySchedule>();
        public ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
    }
}
