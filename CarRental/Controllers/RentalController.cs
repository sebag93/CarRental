using CarRental.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly List<CarViewModel> samochody = WczytywanieSamochodow("C:/KURSY/CarRental/CarRental/Files/cars.csv");

        // GET: Rental/Fleet
        public ActionResult Fleet()
        {
            ViewBag.Cars = samochody;
            return View();
        }

        // GET: Rental/Booking
        [Authorize]
        public ActionResult Booking()
        {
            return View();
        }

        private static List<CarViewModel> WczytywanieSamochodow(string v)
        {
            var zapytanie = System.IO.File.ReadAllLines(v)
                                .Where(l => l.Length > 1)
                                .Select(l =>
                                {
                                    var kolumny = l.Split(',');
                                    return new CarViewModel
                                    {
                                        CarName = kolumny[0],
                                        FuelType = kolumny[1],
                                        Transmission = kolumny[2],
                                        ConsumptionCombined = kolumny[3],
                                        AirConditioning = kolumny[4],
                                        DriveType = kolumny[5],
                                        LuggageCapacity = kolumny[6],
                                        Photo = kolumny[7]
                                    };
                                });

            return zapytanie.ToList();
        }
    }
}