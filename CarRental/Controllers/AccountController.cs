using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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