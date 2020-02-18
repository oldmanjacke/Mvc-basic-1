using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mvc_basic_1.Controllers
{
    public class GuessingController : Controller
    {
     public int RandomNumber()
        {
            Random random_ = new Random();
            return random_.Next(1, 100);

        }
        public IActionResult Index()
        {
            int randomnumber = RandomNumber();
            HttpContext.Session.SetString("MyRandomNumber", randomnumber.ToString());
            return View();

        }

        [HttpPost]
        public IActionResult Index(string myGuess)
        {
            try
            {
                if (string.IsNullOrEmpty(myGuess))
                {
                    ViewBag.Msg = "the field needs a  vaule";
                    return View();
                }

                else if (int.Parse(myGuess)==0)
                {
                    ViewBag.Msg = "you need to enter a number";
                    return View();
                }
                else
                {
                    string randomnumber = HttpContext.Session.GetString("MyRandomNumber");
                    if (int.Parse(myGuess)> int.Parse(randomnumber))
                    {
                        ViewBag.Msg = "Guess a lower number";
                    }
                    else if (int.Parse(myGuess)< int.Parse(randomnumber))
                    {
                        ViewBag.Msg = "Guess a higher number";
                    }
                    else
                    {
                        ViewBag.Msg = "congrats! you got the correct number!";
                    }

                    return View();

                }
            }

            catch (FormatException)
            {
                ViewBag.Msg = "You neet to enter a number";
                return View();
            }
        }
    }

}