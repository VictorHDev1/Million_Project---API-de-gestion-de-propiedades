﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PropertyDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public int IdOwner { get; set; }

  
    }

    public class PropertyImageDto
    {
        public int IdPropertyImage { get; set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
