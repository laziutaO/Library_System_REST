﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsClosed { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
    }
}
