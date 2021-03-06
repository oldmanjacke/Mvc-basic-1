﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_basic_1.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
