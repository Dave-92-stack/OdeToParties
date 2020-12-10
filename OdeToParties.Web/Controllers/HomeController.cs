using OdeToParties.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToParties.Web.Controllers
{
    public class HomeController : Controller
    {
        IPartyData db;

        public HomeController(IPartyData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}