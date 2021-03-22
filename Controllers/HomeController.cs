using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistrationValidation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
