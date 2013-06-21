using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizBuz.Models;

namespace FizBuz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DivEval model = new DivEval();
            return View(model);
        }
    }
}
