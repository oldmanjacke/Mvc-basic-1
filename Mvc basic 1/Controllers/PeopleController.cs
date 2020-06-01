using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc_basic_1.Models;
using Mvc_basic_1.Models.Services;

namespace Mvc_basic_1.Controllers
{
    public class PeopleController : Controller
    {
        readonly PeopleService _peopleService = new PeopleService();
        public IActionResult Index() //List
        {
            return View(_peopleService.All());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PeopleViewModel person) //personViewModel uses to avoid users to access Id
        {
            if (ModelState.IsValid) //Alltid kontrollera input på backend
            {
                _peopleService.Create(person.Name, person.Country);

                return RedirectToAction("Index");
            }
            return View(person); //personViewModel uses to sent wrong input to View 
        }
        public IActionResult Remove(int id)
        {
            bool result = _peopleService.Remove(id);

            if (result)
            { ViewBag.msg = "The person was successfully removed"; }
            else
            { ViewBag.msg = "The person could not be found"; }

            return View("Index", _peopleService.All());

        }
        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Filter(string filterInput)
        {

            return View("Index", _peopleService.Filter(filterInput));
        }

        public IActionResult PersonList()
        {
            return PartialView(_peopleService.All());
        }
        [HttpGet]
        public IActionResult PersonPartialId(int id)
        {
            return PartialView("_PersonPartialId", _peopleService.Find(id));
        }
        [HttpGet]
        public IActionResult PersonCreatePartial()
        {
            return PartialView("_PersonCreatePartial");
        }

        [HttpPost]
        public IActionResult PersonCreatePartial(PeopleViewModel peopleViewModel) //personViewModel uses to avoid users to access Id
        {
            if (ModelState.IsValid)
            {
                return PartialView("_AddToList", _peopleService.Create(peopleViewModel.Name, peopleViewModel.Country));
            }
            return View(peopleViewModel);
        }
        [HttpGet]
        public IActionResult PeopleFilterPartial()
        {
            return PartialView("_PersonFilterPartial");
        }
        [HttpPost]
        public IActionResult PeopleFilterPartial(string filterInput)
        {
            return PartialView("_FilterListItem", _peopleService.Filter(filterInput));
        }
        [HttpGet]
        public IActionResult PeopleRenamePartial(int id)
        {

            return PartialView("_PeopleRenamePartial", _peopleService.Find(id));
        }
        [HttpPost]
        public IActionResult PeopleRenamePartial(PeopleViewModel peopleViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                if (_peopleService.Update(peopleViewModel, id))
                {
                    return PartialView("_AddToList", _peopleService.Find(id));
                }
                return BadRequest();
            }
            return View(peopleViewModel); //Send person back with errormessage throug ModelState.IsValid
        }
    }
}