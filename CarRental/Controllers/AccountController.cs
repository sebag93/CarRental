using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarRental.Models;

namespace CarRental.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
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
        public ActionResult Login(LoginViewModel dane, string ReturnUrl = "")
        {
            string message = "";
            using (CarRentalEntities db = new CarRentalEntities())
            {
                var v = db.Users.Where(x => x.email == dane.Email && x.password == dane.Password).FirstOrDefault();
                if (v != null)
                {
                    int timeout = dane.RememberMe ? 525600 : 20; //525600 minut to 1 rok
                    var ticket = new FormsAuthenticationTicket(dane.Email, dane.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                    {
                        Expires = DateTime.Now.AddMinutes(timeout),
                        HttpOnly = true
                    };
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        //return RedirectToAction(ReturnUrl);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    message = "Wprowadzono niepoprawne dane";
                }
            }
            ViewBag.Message = message;
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

        // GET: Account/Settings
        [AllowAnonymous]
        public ActionResult Settings()
        {
            return View();
        }

        // GET: Account/ChangePassword
        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}