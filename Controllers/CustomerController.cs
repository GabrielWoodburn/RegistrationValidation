using Microsoft.AspNetCore.Mvc;
using RegistrationValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationValidation.Controllers
{
    public class CustomerController : Controller
    {
        private RegistrationContext context;
        public CustomerController(RegistrationContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(RegistrationModel customer)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, customer.EmailAddress);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(RegistrationModel.EmailAddress), msg);
                }
            }
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Welcome");
            }
            else
            {
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Welcome(RegistrationModel customer)
        {
            return View();
        }
    }
}
