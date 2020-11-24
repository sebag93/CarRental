using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer
        public ActionResult Offer()
        {
            return View();
        }

        public ActionResult ShortTimeRental()
        {
            return View();
        }

        public ActionResult LongTimeRental()
        {
            return View();
        }
        public ActionResult ProtectionPackage()
        {
            return View();
        }
        public ActionResult Extras()
        {
            return View();
        }
    }
}