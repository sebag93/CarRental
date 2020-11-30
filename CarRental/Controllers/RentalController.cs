using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly List<CarViewModel> samochody = WczytywanieSamochodow("C:/KURSY/CarRental/CarRental/Files/cars.csv");

        // GET: Rental/Fleet
        [AllowAnonymous]
        public ActionResult Fleet()
        {
            ViewBag.Cars = samochody;
            return View();
        }

        // GET: Rental/Booking
        public ActionResult Booking()
        {
            var carList = new List<string>();
            foreach (var item in samochody)
            {
                carList.Add(item.CarName);
            }
            ViewBag.Cars = carList;
            return View(new BookingViewModel { CarName = carList[0] });
        }

        // POST: Rental/Booking
        [HttpPost]
        public ActionResult Booking(BookingViewModel car)
        {
            bool Status = false;
            string message = "";
            using (CarRentalEntities db = new CarRentalEntities())
            {
                    if (ModelState.IsValid)
                    {
                        var bookingCar = new Booking()
                        {
                            StartDate = car.StartDate,
                            EndDate = car.EndDate,
                            CarName = car.CarName,
                            Email = HttpContext.User.Identity.Name
                        };
                        db.Booking.Add(bookingCar);
                        db.SaveChanges();
                        message = "Rezerwacja zakończona pomyślnie. Dziękujemy za skorzystanie z naszej oferty. Historię rezerwacji możesz sprawdzić w panelu swojego konta użytkownika.";
                        Status = true;
                    }
                    else
                    {
                        message = "Nieprawidłowe żądanie";
                        Status = false;
                    }
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(car);
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