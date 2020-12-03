using CarRental.Models;
using CarRental.Services.Business;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRental.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SecurityService securityService = new SecurityService();
        private readonly CarRentalEntities db = new CarRentalEntities();
        private string message;
        private bool Status;

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            bool success = securityService.Authenticate(user);
            if (success)
            {
                int timeout = user.RememberMe ? 60 : 20;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.Email, user.RememberMe, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                {
                    Expires = ticket.Expiration,
                    HttpOnly = true
                };
                HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                message = "Wprowadzono niepoprawne dane";
            }
            ViewBag.Message = message;
            ViewBag.Status = success;
            return View();
        }

        //Logout
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModels user)
        {
            if (ModelState.IsValid)
            {
                if (securityService.EmailExist(user.Email))
                {
                    message = "Podany email został już zarejestrowany";
                }
                else {
                    var newuser = new Users()
                    {
                        email = user.Email,
                        password = user.Password,
                        firstname = user.FirstName,
                        lastname = user.LastName,
                        city = user.City,
                        address = user.Address,
                        number = user.Number,
                        zipcode = user.ZipCode,
                        phonenumber = user.PhoneNumber
                    };
                    db.Users.Add(newuser);
                    db.SaveChanges();
                    message = "Rejestracja zakończona pomyślnie. Możesz zalogować sie na swoje konto.";
                    Status = true;
                }
            }
            else
            {
                message = "Nieprawidłowe żądanie";
                Status = false;
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        // GET: Account/Settings
        public ActionResult Settings()
        {
            return View();
        }

        // GET: Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel user)
        {
            string email = User.Identity.Name;
            Users userExists = db.Users.SingleOrDefault(x => x.email == email && x.password == user.CurrentPassword);
            if (userExists != null)
            {
                userExists.password = user.NewPassword;
                db.SaveChanges();
                message = "Hasło zmienione pomyślnie.";
                Status = true;
            }
            else
            {
                message = "Wprowadzone aktualne hasło jest nieprawidłowe.";
                Status = false;
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        // GET: Account/DeleteAccount
        public ActionResult DeleteAccount()
        {
            return View();
        }

        // POST: Account/DeleteAccount
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccount(string email)
        {
            email = User.Identity.Name;
            Users toDelete = db.Users.SingleOrDefault(x => x.email == email);
            db.Users.Remove(toDelete);
            var booking = db.Booking.Where(x => x.Email == email);
            db.Booking.RemoveRange(booking);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Booking
        public ActionResult Booking()
        {
            var booking = db.Booking.Where(x => x.Email == User.Identity.Name).ToList();
            ViewBag.Booking = booking;
            return View();
        }
    }
}