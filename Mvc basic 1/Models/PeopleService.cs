using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_basic_1.Models.Services
{
    public class PeopleService : IPeopleService
    {
        static int idCounter = 3;
        public string filterInput = "";
        private static List<People> peopleList = new List<People>();

        static PeopleService()
        {
            peopleList.Add(new People() { Id = 1, Name = "Elvira", Country = "Sverige" });
            peopleList.Add(new People() { Id = 2, Name = "Klara", Country = "Sverige" });
            peopleList.Add(new People() { Id = 3, Name = "Charles", Country = "England" });
        }

        public List<People> All()
        {
            return peopleList;
        }
        public People Create(string name, string country)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(country))
            {
                return null;
            }

            People person = new People()
            {
                Id = ++idCounter,
                Name = name,
                Country = country
            };

            peopleList.Add(person);
            return person;
        }

        public bool Remove(int id)
        {
            foreach (People item in peopleList)
            {
                if (item.Id == id)
                {
                    peopleList.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public People Find(int id)
        {
            return peopleList.SingleOrDefault(person => person.Id == id);
        }

        public List<People> Filter(string filterInput)
        {
            List<People> filterPersonList = new List<People>();
            foreach (People item in peopleList)
            {
                if (item.Name == filterInput || item.Country == filterInput)
                {
                    filterPersonList.Add(item);
                }
            }
            return filterPersonList;
        }

        public bool Update(PeopleViewModel personViewModel, int id)
        {
            if (personViewModel == null)
            {
                return false;
            }

            People currentPeople = Find(id);

            if (id == 0)
            {
                return false;
            }

            currentPeople.Name = personViewModel.Name;
            currentPeople.Country = personViewModel.Country;

            //personList.Update(currentPerson);

            return true;
        }

    }
}
