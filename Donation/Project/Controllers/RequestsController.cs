using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using PagedList;
using PagedList.Mvc;

namespace Project.Controllers
{
    public class RequestsController : Controller
    {
        private RequestContext db = new RequestContext();

        // GET: Requests
        public ActionResult Index(string donationType, string searchString, int? page)
        {
            var MajorLst = new List<string>();
            var MajorQry = from d in db.Requests orderby d.Item select d.Item;
            MajorLst.AddRange(MajorQry.Distinct());
            ViewBag.donationType = new SelectList(MajorLst);

            var donation = from m in db.Requests select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                donation = donation.Where(s => s.Item.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(donationType))
            {
                donation = donation.Where(x => x.Item == donationType);
            }
            return View(donation.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Item,Fname,Lname")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Item,Fname,Lname")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
