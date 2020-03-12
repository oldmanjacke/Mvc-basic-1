using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mvc_basic_1.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PersonController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            return View(_peopleService.GetPeople());
        }

        public IActionResult Details(int id)
        {

        }

        public IActionResult Create()
        {
            return View();
        }
    }
}