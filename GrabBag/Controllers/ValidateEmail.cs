using GrabBag.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrabBag.Controllers
{
    public class ValidateEmail : Controller
    {
        private RegistrationContext context;
        public ValidateEmail(RegistrationContext ctx) => context = ctx;

        public JsonResult CheckEmail(string emailAddress)
        {
            string msg = Check.EmailExists(context, emailAddress);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
