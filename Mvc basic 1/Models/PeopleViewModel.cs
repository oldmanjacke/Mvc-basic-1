using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_basic_1.Models
{
    public class PeopleViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Must have a Name that is 2 letter long")]
        [Display(Name = "Förnamn")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must have a Name that is 2 letter long")]
        public string Country { get; set; }

    }
}
