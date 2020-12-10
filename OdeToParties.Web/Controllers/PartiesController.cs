using OdeToParties.Data.Models;
using OdeToParties.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToParties.Web.Controllers
{
    public class PartiesController : Controller
    {
        private readonly IPartyData db;

        public PartiesController(IPartyData db)
        {
            this.db = db;
        }
        // GET: Parties
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Party party)
        {
            if (ModelState.IsValid)
            {
                db.Add(party);
                TempData["Message"] = "The party was added successfully!";
                return RedirectToAction("Details", new { id = party.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Party party)
        {
            if(ModelState.IsValid)
            {
                db.Update(party);
                TempData["Message"] = "The party has been updated!";
                return RedirectToAction("Details", new { id = party.Id });
            }
            return View(party);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            TempData["Message"] = "The party was deleted!";
            return RedirectToAction("Index");
        }
    }
}