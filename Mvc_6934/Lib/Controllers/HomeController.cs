using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Controllers
{
    public class LibController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
