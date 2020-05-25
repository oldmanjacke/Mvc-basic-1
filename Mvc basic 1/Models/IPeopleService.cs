using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_basic_1.Models.Services
{
    public interface IPeopleService
    {

        People Create(string name, string country);
        bool Remove(int id);
        List<People> All();
        List<People> Filter(string filterInput);
        bool Update(PeopleViewModel peopleViewModel, int id);
        People Find(int id);
    }
}

