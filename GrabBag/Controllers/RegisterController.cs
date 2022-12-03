using GrabBag.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GrabBag.Controllers
{
    public class RegisterController : Controller
    {
        private RegistrationContext context;
        public RegisterController(RegistrationContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Register register)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, register.EmailAddress);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Register.EmailAddress), msg);
                }
            }

            if (ModelState.IsValid)
            {
                context.Registers.Add(register);
                context.SaveChanges();
                return RedirectToAction("Welcome");
            }
            else
            {
                return View(register);
            }
        }

        [HttpGet]
        public IActionResult Welcome(RegisterController register)
        {
            return View();
        }
    }
}
