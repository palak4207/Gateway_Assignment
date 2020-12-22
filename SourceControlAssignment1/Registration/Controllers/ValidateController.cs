using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Models;

namespace Registration.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ValidateClass vc)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}