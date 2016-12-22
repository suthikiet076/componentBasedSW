using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private DonationContext db = new DonationContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}