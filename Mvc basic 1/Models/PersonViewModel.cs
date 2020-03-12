using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_basic_1.Models
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public double Age { get; set; }

        public bool Adress { get; set; }

        public bool City { get; set; }

        public PersonViewModel() { }//zero constuctor (no input arguments)
        public PersonViewModel(People people)
        {
            Name = people.Name;
            Age = people.Age;
            Adress = people.Adress;
            City = people.City;
        }
    }
}
