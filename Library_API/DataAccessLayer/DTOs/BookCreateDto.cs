﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public record struct BookCreateDto(string Title, string Category, int AvailableSamples);
    
}