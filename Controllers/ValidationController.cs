using Microsoft.AspNetCore.Mvc;
using RegistrationValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationValidation.Controllers
{
    public class ValidationController : Controller
    {
        private RegistrationContext context;
        public ValidationController(RegistrationContext ctx) => context = ctx;

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
