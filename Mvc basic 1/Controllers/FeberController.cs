using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mvc_basic_1.Controllers
{
    public class FeberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}