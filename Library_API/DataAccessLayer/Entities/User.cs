using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        
        public string Password { get; set; } = null!;

        public bool IsBlocked { get; set; }

    }
}
