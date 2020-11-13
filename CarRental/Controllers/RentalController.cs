using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental/Offer
        public ActionResult Offer()
        {
            return View();
        }

        // GET: Rental/Fleet
        public ActionResult Fleet()
        {
            return View();
        }
    }
}